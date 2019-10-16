using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace STARC.Model
{
    public class Database
    {
        // Caminho no S.O. do dispositivo para a pasta do BD
        string DiretorioBase = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        // Flag para verificar se as tabelas já foram criadas no BDs
        bool TabelasCriadas = false;

        public SQLiteConnection Conexao()
        {
            SQLiteConnection cnx = new SQLiteConnection(Path.Combine(DiretorioBase, "base.db"));

            // Tenta criar as tabelas na primeira conexão
            if (!TabelasCriadas)
            {
                cnx.DropTable<Componente>();
                cnx.DropTable<Usuario>();
                cnx.CreateTable<Componente>();
                cnx.CreateTable<Usuario>();
                TabelasCriadas = true;
            }

            return cnx;
        }
    }
}
