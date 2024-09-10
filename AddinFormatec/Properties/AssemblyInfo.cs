using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(InfoAssembly.TitleView)]
[assembly: AssemblyDescription(InfoAssembly.DescrView)]
[assembly: AssemblyConfiguration(InfoAssembly.Configuration)]
[assembly: AssemblyCompany(InfoAssembly.Company)]
[assembly: AssemblyProduct(InfoAssembly.Product)]
[assembly: AssemblyCopyright(InfoAssembly.Copyright)]
[assembly: AssemblyTrademark(InfoAssembly.Trademark)]
[assembly: AssemblyCulture(InfoAssembly.Culture)]

[assembly: ComVisible(true)]

[assembly: Guid("0247c45e-9282-48d5-9c70-d8ef03a539ee")]

[assembly: AssemblyVersion(InfoAssembly.Version)]
[assembly: AssemblyFileVersion(InfoAssembly.Version)]

public class InfoAssembly {
  public const string Version = "1.0.0.4";

  public const string TitleView = "Addin Leonardo Michalak";

  public const string DescrView = "Sistema de Gerenciamento de projetos";

  public const string Copyright = "Copyright © 2024 Leonardo Adriano Michalak. Todos os direitos reservados.";
  public const string Company = "Leonardo Adriano Michalak";
  public const string Product = "Suplemento Solidworks para Gerenciamento de Projetos";
  public const string Configuration = "";
  public const string Trademark = "";
  public const string Culture = "";
}
