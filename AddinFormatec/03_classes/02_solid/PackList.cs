using LmCorbieUI;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AddinFormatec {
  public class PackList {
    [DisplayName("ID")]
    public int IdVolume { get; set; }

    [DisplayName("COMPONENTE")]
    public string NomeComponente { get; set; }

    [Browsable(false)]
    public string PathName { get; set; }

    [DisplayName("VOLUME")]
    public string DescricaoVolume { get; set; }

    [DisplayName("DESCRIÇÃO")]
    public string DescricaoItem { get; set; }

    [Browsable(false)]
    public string NomeConfiguracao { get; set; }

    [DisplayName("QTD")]
    public int QtdItem { get; set; }

    public static List<PackList> GetPackLit(out List<Z_Padrao> descVolumes) {
      var packListEstrutura = new ComponenteEstrutura();
      var listaPackList = new List<PackList>();
      List<Z_Padrao> descricaoVolumes = new List<Z_Padrao>();

      try {
        SldWorks swApp = new SldWorks();
        ModelDoc2 swModel = (ModelDoc2)swApp.ActiveDoc;

        ConfigurationManager swConfMgr;
        Configuration swConf;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;

        string valOut;
        string resolvedValOut;

        ModelDocExtension swModelDocExt = swModel.Extension;
        CustomPropertyManager swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        packListEstrutura.Nivel = "1";
        packListEstrutura.Quantidade = 1;
        swCustPropMngr.Get2("CHECK", out valOut, out resolvedValOut);
        packListEstrutura.Check = resolvedValOut;
        swCustPropMngr.Get2("ItemPai", out valOut, out resolvedValOut);
        packListEstrutura.EhItemPai = resolvedValOut == "Sim" ? true : false;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager(swConf.Name);
        swCustPropMngr.Get2("sgl_DescricaoEspecifica", out valOut, out resolvedValOut);
        packListEstrutura.Denominacao = resolvedValOut;

        // Inserir lista de material e pegar dados
        string lista = Config.model.ListaMontagem;

        int BomType = (int)swBomType_e.swBomType_Indented;
        int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;

        var swBOMAnnotation = swModelDocExt.InsertBomTable3(lista, 0, 1, BomType, swConf.Name, Hidden: false, NumberingType, DetailedCutList: true);
        PegaDadosLista(swApp, swBOMAnnotation, packListEstrutura, descricaoVolumes);

        ListaCorte.ExcluirLista(swModel);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar PackList\n\n{ex.Message}", "Addin LM Projetos",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      var pkListMontado = MontarPackList(packListEstrutura, listaPackList, descricaoVolumes);

      var idsObsoletos = new List<int>();
      for (int i = 0; i < descricaoVolumes.Count; i++) {
        Z_Padrao descVol = descricaoVolumes[i];
        if (!pkListMontado.Any(x => x.IdVolume == descVol.Codigo)) {
          idsObsoletos.Add(i);
        }
      }

      idsObsoletos.ForEach(x => { descricaoVolumes.RemoveAt(x); });

      for (int i = 1; i <= descricaoVolumes.Count; i++) {
        var descVol = descricaoVolumes[i - 1];

        if (i != descVol.Codigo) {
          pkListMontado.Where(x => x.IdVolume == descVol.Codigo).ToList().ForEach(x => { x.IdVolume = i; });
          descVol.Codigo = i;
        }
      }

      descVolumes = descricaoVolumes;

      return pkListMontado;
    }

    private static void PegaDadosLista(SldWorks swApp, BomTableAnnotation swBOMAnnotation, ComponenteEstrutura packListEstrutura, List<Z_Padrao> descricaoVolumes) {
      string nameShort = "";
      try {
        string[] vModelPathNames = null;
        string strItemNumber = null;
        string strPartNumber = null;
        var swTableAnnotation = (TableAnnotation)swBOMAnnotation;

        string valOut;
        string resolvedValOut;

        int lStartRow = swTableAnnotation.TotalRowCount - 1;

        var swBOMFeature = swBOMAnnotation.BomFeature;

        for (int i = lStartRow; i >= 0; i--) {
          vModelPathNames = (string[])swBOMAnnotation.GetModelPathNames(i, out strItemNumber, out strPartNumber);

          if (vModelPathNames != null) {
            string pathName = vModelPathNames[0];
            var nomeComp = swTableAnnotation.get_Text(i, 1).Trim();

            if (string.IsNullOrEmpty(nomeComp))
              continue;

            if (int.TryParse(swTableAnnotation.get_Text(i, 3).Trim(), out int qtd)) {
              ModelDoc2 swModel = default(ModelDoc2);
              if (Path.GetExtension(pathName).ToLower() == ".sldprt")
                swModel = (ModelDoc2)swApp.OpenDoc(pathName, (int)swDocumentTypes_e.swDocPART);
              else
                swModel = (ModelDoc2)swApp.OpenDoc(pathName, (int)swDocumentTypes_e.swDocASSEMBLY);

              if (swModel != null) {
                ModelDocExtension swModelDocExt;

                ConfigurationManager swConfMgr;
                Configuration swConf;

                swModelDocExt = swModel.Extension;
                swConfMgr = swModel.ConfigurationManager;
                swConf = swConfMgr.ActiveConfiguration;

                var packListnew = new ComponenteEstrutura();
                packListnew.NomeComponente = nomeComp;
                packListnew.PathName = pathName;
                packListnew.Nivel = "1." + swTableAnnotation.get_Text(i, 0);
                packListnew.Quantidade = qtd;
                packListnew.Denominacao = swTableAnnotation.get_Text(i, 2).Trim();
                packListnew.ConfigName = swConf.Name;

                CustomPropertyManager swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

                swCustPropMngr.Get2("CHECK", out valOut, out resolvedValOut);
                packListnew.Check = resolvedValOut;
                swCustPropMngr.Get2("ItemPai", out valOut, out resolvedValOut);
                packListnew.EhItemPai = resolvedValOut == "Sim" ? true : false;

                var descTemp = $"{packListnew.Check} - FIXAÇÃO";

                if (!string.IsNullOrEmpty(packListnew.Check) && !descricaoVolumes.Any(x => x.Descricao == packListnew.Check)) {
                  var codDesc = descricaoVolumes.Count > 0 ? descricaoVolumes[descricaoVolumes.Count - 1].Codigo + 1 : 1;
                  descricaoVolumes.Add(new Z_Padrao {
                    Codigo = codDesc,
                    Descricao = packListnew.Check
                  });

                  if (packListnew.EhItemPai) {
                    codDesc = descricaoVolumes.Count > 0 ? descricaoVolumes[descricaoVolumes.Count - 1].Codigo + 1 : 1;
                    descricaoVolumes.Add(new Z_Padrao {
                      Codigo = codDesc,
                      Descricao = descTemp
                    });
                  }
                } else if (!string.IsNullOrEmpty(packListnew.Check) && packListnew.EhItemPai && !descricaoVolumes.Any(x => x.Descricao == descTemp)) {
                  var codDesc = descricaoVolumes.Count > 0 ? descricaoVolumes[descricaoVolumes.Count - 1].Codigo + 1 : 1;
                  descricaoVolumes.Add(new Z_Padrao {
                    Codigo = codDesc,
                    Descricao = descTemp
                  });
                }

                var splNivel = packListnew.Nivel.Split('.');

                switch (splNivel.Length) {
                  case 2: {
                      packListEstrutura.CompFilhos.Add(packListnew);
                    }
                    break;
                  case 3: {
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          itemN1.CompFilhos.Add(packListnew);
                          break;
                        }
                      }
                    }
                    break;
                  case 4: {
                      bool jaFoiAdd = false;
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          foreach (var itemN2 in itemN1.CompFilhos) {
                            if (itemN2.Nivel == nv3) {
                              itemN2.CompFilhos.Add(packListnew);
                              jaFoiAdd = true;
                              break;
                            }
                          }
                        }
                        if (jaFoiAdd)
                          break;
                      }
                    }
                    break;
                  case 5: {
                      bool jaFoiAdd = false;
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                      var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          foreach (var itemN2 in itemN1.CompFilhos) {
                            if (itemN2.Nivel == nv3) {
                              foreach (var itemN3 in itemN2.CompFilhos) {
                                if (itemN3.Nivel == nv4) {
                                  itemN3.CompFilhos.Add(packListnew);
                                  jaFoiAdd = true;
                                  break;
                                }
                              }
                            }
                            if (jaFoiAdd)
                              break;
                          }

                        }
                        if (jaFoiAdd)
                          break;
                      }
                    }
                    break;
                  case 6: {
                      bool jaFoiAdd = false;
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                      var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                      var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          foreach (var itemN2 in itemN1.CompFilhos) {
                            if (itemN2.Nivel == nv3) {
                              foreach (var itemN3 in itemN2.CompFilhos) {
                                if (itemN3.Nivel == nv4) {
                                  foreach (var itemN4 in itemN3.CompFilhos) {
                                    if (itemN4.Nivel == nv5) {
                                      itemN4.CompFilhos.Add(packListnew);
                                      jaFoiAdd = true;
                                      break;
                                    }
                                  }
                                }
                                if (jaFoiAdd)
                                  break;
                              }
                            }
                            if (jaFoiAdd)
                              break;
                          }
                        }
                        if (jaFoiAdd)
                          break;
                      }
                    }
                    break;
                  case 7: {
                      bool jaFoiAdd = false;
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                      var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                      var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                      var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          foreach (var itemN2 in itemN1.CompFilhos) {
                            if (itemN2.Nivel == nv3) {
                              foreach (var itemN3 in itemN2.CompFilhos) {
                                if (itemN3.Nivel == nv4) {
                                  foreach (var itemN4 in itemN3.CompFilhos) {
                                    if (itemN4.Nivel == nv5) {
                                      foreach (var itemN5 in itemN4.CompFilhos) {
                                        if (itemN5.Nivel == nv6) {
                                          itemN5.CompFilhos.Add(packListnew);
                                          jaFoiAdd = true;
                                          break;
                                        }
                                      }
                                    }
                                    if (jaFoiAdd)
                                      break;
                                  }
                                }
                                if (jaFoiAdd)
                                  break;
                              }
                            }
                            if (jaFoiAdd)
                              break;
                          }
                        }
                        if (jaFoiAdd)
                          break;
                      }
                    }
                    break;
                  case 8: {
                      bool jaFoiAdd = false;
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                      var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                      var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                      var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                      var nv7 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          foreach (var itemN2 in itemN1.CompFilhos) {
                            if (itemN2.Nivel == nv3) {
                              foreach (var itemN3 in itemN2.CompFilhos) {
                                if (itemN3.Nivel == nv4) {
                                  foreach (var itemN4 in itemN3.CompFilhos) {
                                    if (itemN4.Nivel == nv5) {
                                      foreach (var itemN5 in itemN4.CompFilhos) {
                                        if (itemN5.Nivel == nv6) {
                                          foreach (var itemN6 in itemN5.CompFilhos) {
                                            if (itemN6.Nivel == nv7) {
                                              itemN6.CompFilhos.Add(packListnew);
                                              jaFoiAdd = true;
                                              break;
                                            }
                                          }
                                        }
                                        if (jaFoiAdd)
                                          break;
                                      }
                                    }
                                    if (jaFoiAdd)
                                      break;
                                  }
                                }
                                if (jaFoiAdd)
                                  break;
                              }
                            }
                            if (jaFoiAdd)
                              break;
                          }
                        }
                        if (jaFoiAdd)
                          break;
                      }
                    }
                    break;
                  case 9: {
                      bool jaFoiAdd = false;
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                      var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                      var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                      var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                      var nv7 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}";
                      var nv8 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}.{splNivel[7]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          foreach (var itemN2 in itemN1.CompFilhos) {
                            if (itemN2.Nivel == nv3) {
                              foreach (var itemN3 in itemN2.CompFilhos) {
                                if (itemN3.Nivel == nv4) {
                                  foreach (var itemN4 in itemN3.CompFilhos) {
                                    if (itemN4.Nivel == nv5) {
                                      foreach (var itemN5 in itemN4.CompFilhos) {
                                        if (itemN5.Nivel == nv6) {
                                          foreach (var itemN6 in itemN5.CompFilhos) {
                                            if (itemN6.Nivel == nv7) {
                                              foreach (var itemN7 in itemN6.CompFilhos) {
                                                if (itemN7.Nivel == nv8) {
                                                  itemN7.CompFilhos.Add(packListnew);
                                                  jaFoiAdd = true;
                                                  break;
                                                }
                                              }
                                            }
                                            if (jaFoiAdd)
                                              break;
                                          }
                                        }
                                        if (jaFoiAdd)
                                          break;
                                      }
                                    }
                                    if (jaFoiAdd)
                                      break;
                                  }
                                }
                                if (jaFoiAdd)
                                  break;
                              }
                            }
                            if (jaFoiAdd)
                              break;
                          }
                        }
                        if (jaFoiAdd)
                          break;
                      }
                    }
                    break;
                  case 10: {
                      bool jaFoiAdd = false;
                      var nv2 = $"{splNivel[0]}.{splNivel[1]}";
                      var nv3 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}";
                      var nv4 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}";
                      var nv5 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}";
                      var nv6 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}";
                      var nv7 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}";
                      var nv8 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}.{splNivel[7]}";
                      var nv9 = $"{splNivel[0]}.{splNivel[1]}.{splNivel[2]}.{splNivel[3]}.{splNivel[4]}.{splNivel[5]}.{splNivel[6]}.{splNivel[7]}.{splNivel[8]}";
                      foreach (var itemN1 in packListEstrutura.CompFilhos) {
                        if (itemN1.Nivel == nv2) {
                          foreach (var itemN2 in itemN1.CompFilhos) {
                            if (itemN2.Nivel == nv3) {
                              foreach (var itemN3 in itemN2.CompFilhos) {
                                if (itemN3.Nivel == nv4) {
                                  foreach (var itemN4 in itemN3.CompFilhos) {
                                    if (itemN4.Nivel == nv5) {
                                      foreach (var itemN5 in itemN4.CompFilhos) {
                                        if (itemN5.Nivel == nv6) {
                                          foreach (var itemN6 in itemN5.CompFilhos) {
                                            if (itemN6.Nivel == nv7) {
                                              foreach (var itemN7 in itemN6.CompFilhos) {
                                                if (itemN7.Nivel == nv8) {
                                                  foreach (var itemN8 in itemN7.CompFilhos) {
                                                    if (itemN8.Nivel == nv9) {
                                                      itemN8.CompFilhos.Add(packListnew);
                                                      jaFoiAdd = true;
                                                      break;
                                                    }
                                                  }
                                                }
                                                if (jaFoiAdd)
                                                  break;
                                              }
                                            }
                                            if (jaFoiAdd)
                                              break;
                                          }
                                        }
                                        if (jaFoiAdd)
                                          break;
                                      }
                                    }
                                    if (jaFoiAdd)
                                      break;
                                  }
                                }
                                if (jaFoiAdd)
                                  break;
                              }
                            }
                            if (jaFoiAdd)
                              break;
                          }
                        }
                        if (jaFoiAdd)
                          break;
                      }
                    }
                    break;
                  default:
                  MsgBox.Show("Item com mais de oito níveis");
                  break;
                }
              }
            };
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar dados da Lista Pack List\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static List<PackList> MontarPackList(ComponenteEstrutura packListEstrutura, List<PackList> listaPackList, List<Z_Padrao> descricaoVolumes) {
      try {
        PercorrerComponentes(packListEstrutura, listaPackList, descricaoVolumes);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Montar PackList\n\n{ex.Message}", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return listaPackList.OrderBy(x => x.IdVolume).ToList();
    }

    private static void PercorrerComponentes(ComponenteEstrutura packListEstrutura, List<PackList> listaPackList, List<Z_Padrao> descricaoVolumes) {
      for (int i = 0; i < packListEstrutura.CompFilhos.Count; i++) {
        var comp = packListEstrutura.CompFilhos[i];

        if (comp != null && !string.IsNullOrEmpty(comp.Check)) {
          var itemExistaente = listaPackList.Where(x => x.NomeComponente == comp.NomeComponente && x.DescricaoVolume == comp.Check && x.NomeConfiguracao == comp.ConfigName).FirstOrDefault();

          if (itemExistaente != null) {
            itemExistaente.QtdItem += comp.Quantidade * packListEstrutura.Quantidade;
          } else {
            listaPackList.Add(new PackList {
              NomeComponente = comp.NomeComponente,
              PathName = comp.PathName,
              DescricaoItem = comp.Denominacao,
              DescricaoVolume = comp.Check,
              QtdItem = comp.Quantidade * packListEstrutura.Quantidade,
              NomeConfiguracao = comp.ConfigName,
              IdVolume = descricaoVolumes.Where(x => x.Descricao == comp.Check).FirstOrDefault().Codigo,
            });
          }
          if (comp.EhItemPai) {
            PercorrerComponentesFixacao(comp, $"{comp.Check} - FIXAÇÃO", listaPackList, descricaoVolumes);
          }
        }

        if (string.IsNullOrEmpty(comp.Check) && packListEstrutura.CompFilhos[i].CompFilhos.Count > 0) {
          PercorrerComponentes(packListEstrutura.CompFilhos[i], listaPackList, descricaoVolumes);
        }
      }
    }

    private static void PercorrerComponentesFixacao(ComponenteEstrutura item, string descCheck, List<PackList> listaPackList, List<Z_Padrao> descricaoVolumes) {
      for (int i = 0; i < item.CompFilhos.Count; i++) {
        var comp = item.CompFilhos[i];

        if (comp != null && comp.Check == "FIXAÇÃO") {
          var itemExistaente = listaPackList.Where(x => x.NomeComponente == comp.NomeComponente && x.DescricaoVolume == descCheck && x.NomeConfiguracao == comp.ConfigName).FirstOrDefault();
          if (itemExistaente != null) {
            itemExistaente.QtdItem += comp.Quantidade * item.Quantidade;
          } else {
            listaPackList.Add(new PackList {
              DescricaoItem = comp.Denominacao,
              DescricaoVolume = descCheck,
              QtdItem = comp.Quantidade * item.Quantidade,
              NomeConfiguracao = comp.ConfigName,
              IdVolume = descricaoVolumes.Where(x => x.Descricao == descCheck).FirstOrDefault().Codigo,
            });
          }


          //comp.FoiAdicionado = true;
        }

        //if (item.CompFilhos[i].CompFilhos.Count > 0)
        //{
        //    PercorrerComponentesFixacao(item.CompFilhos[i], descCheck, listaPackList, descricaoVolumes);
        //}
      }
    }

    public static string GetDenominacao() {
      string _return = "";

      try {
        ModelDocExtension swModelDocExt = default(ModelDocExtension);
        CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);
        ConfigurationManager swConfMgr;
        Configuration swConf;

        SldWorks swApp = new SldWorks();
        ModelDoc2 swModel = (ModelDoc2)swApp.ActiveDoc;
        swModelDocExt = swModel.Extension;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager(swConf.Name);

        swCustPropMngr.Get2("sgl_DescricaoEspecifica", out string valOut, out string resolvedValOut);
        _return = resolvedValOut;
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar descrição\n\n{ex.Message}", "Addin LM Projetos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _return;
    }

  }
}
