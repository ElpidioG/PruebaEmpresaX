using Android.Content;
using Android.Database.Sqlite;
using Microsoft.Data.Sqlite;
using SQLite;
public class Database : SQLiteOpenHelper
{
    private const string NombreBaseDeDatos = "EmpresaX.db";
    private const int VersionBaseDeDatos = 1;

    public Database(Context context) : base(context, NombreBaseDeDatos, null, VersionBaseDeDatos)
    {
    }

    public override void OnCreate(SQLiteDatabase db)
    {
        // Aquí puedes crear las tablas de la base de datos
        db.ExecSQL("CREATE TABLE IF NOT EXISTS MiTabla (Id INTEGER PRIMARY KEY, Nombre TEXT)");
    }

    public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
        // Aquí puedes actualizar la estructura de la base de datos si cambia la versión
    }
}