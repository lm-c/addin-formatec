using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Data.SQLite;

namespace AddinFormatec {
  [DbConfigurationType(typeof(SQLiteConfiguration))]
  internal class SQLiteContexto : DbContext {
    static SQLiteContexto() {
      // This will register the SQLite provider without requiring app.config changes
      DbConfiguration.SetConfiguration(new SQLiteConfiguration());
    }

    public SQLiteContexto() : base(ConexaoSQLite.GetConexao(), true) {
        //Database.Connection.ConnectionString = ConexaoSQLite.ConnectionString;
      }

    public DbSet<FormatoFolha> FormatoFolha { get; set; }
    public DbSet<Config> Config { get; set; } 
    public DbSet<MateriaPrima> MateriaPrima { get; set; } 
    public DbSet<PostgresAccess> PostgresAccess { get; set; } 
    public DbSet<CodigoMaquina> CodigoMaquina { get; set; } 
    public DbSet<ImportacaoProjeto> ImportacaoProjeto { get; set; } 

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        modelBuilder.Conventions
            .Remove<PluralizingTableNameConvention>();
        base.OnModelCreating(modelBuilder);
      }
    }
}
