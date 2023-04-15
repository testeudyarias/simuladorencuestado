class Program
{
    public static void Main(string[] args) {

        CantidadEncuestados(521);
        Console.ReadKey();
    }

    public static void CantidadEncuestados(int totalEncuestado) {
        for (int i = 1; i <= totalEncuestado; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"**********************************  {i}   *********************************************");
            Encuestado();
        }
    }

    public static void Encuestado() {

        Microsoft.Data.SqlClient.SqlConnectionStringBuilder stringBuilder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder();
        stringBuilder.InitialCatalog = "db_encuestado";
        stringBuilder.IntegratedSecurity = true;
        stringBuilder.DataSource = @"(localdb)\mssqllocaldb";

        Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(stringBuilder.ConnectionString);
        con.Open();

        Random random = new Random();

        /*
         ¿Cuáles son las limitaciones más significativas que ha encontrado al buscar su primer empleo como egresado o pasante?
        Falta de experiencia laboral
        Baja remuneración ofrecida
        Escasa oferta laboral en su área
        Competencia con otros candidatos con mayor experiencia
        Totas las anteriores
        
         */
        string p1 = "¿Cuáles son las limitaciones más significativas que ha encontrado al buscar su primer empleo como egresado o pasante?";
        string[] resp1 = new string[] {
            "Falta de experiencia laboral",
            "Baja remuneración ofrecida",
            "Escasa oferta laboral en su área",
            "Competencia con otros candidatos con mayor experiencia",
            "Totas las anteriores"
        };
        string r1 = resp1[random.NextInt64(0, resp1.Length)];
        Console.WriteLine(r1);


        /*
         ¿Cuál ha sido la forma más efectiva en la que ha accedido a las vacantes disponibles en su carrera? 
        Bolsas de trabajo en línea
        Contactando directamente a las empresas de su interés
        Asistiendo a ferias de empleo
        Consultando a su departamento de orientación laboral en la universidad
         */
        string p2 = "¿Cuál ha sido la forma más efectiva en la que ha accedido a las vacantes disponibles en su carrera?";
        string[] resp2 = new string[] {
            "Bolsas de trabajo en línea",
            "Contactando directamente a las empresas de su interés",
            "Asistiendo a ferias de empleo",
            "Consultando a su departamento de orientación laboral en la universidad"
        };
        string r2 = resp2[random.NextInt64(0, resp2.Length)];
        Console.WriteLine(r2);
        /*
         ¿Cómo ha hecho frente a los requerimientos del mercado laboral en su carrera?
        Adquiriendo habilidades y conocimientos adicionales a su carrera a través de cursos y certificaciones
        Desarrollando habilidades blandas, como liderazgo, trabajo en equipo y comunicación
        Adaptándose a los cambios en el mercado laboral y la tecnología
        Manteniéndose informado sobre las tendencias y requerimientos del mercado laboral en su carrera
        Todas las anteriores
         */
        string p3 = "¿Cómo ha hecho frente a los requerimientos del mercado laboral en su carrera?";
        string[] resp3 = new string[] {
            "Asistiendo a cursos y talleres de capacitación",
            "Manteniéndose informado a través de medios digitales especializados",
            "Participando en proyectos y actividades extracurriculares relacionados con su carrera",
            "Todas las anteriores"
        };
        string r3 = resp3[random.NextInt64(0, resp3.Length)];
        Console.WriteLine(r3);

        /*
         ¿Considera usted que la universidad ha encontrado alguna solución para reclutar pasantes o egresados?
        Sí
        No 
        No Responde
         */
        string p4 = "¿Considera usted que la universidad ha encontrado alguna solución para reclutar pasantes o egresados?";
        string[] resp4 = new string[] {
            "Sí",
            "No",
            "No Responde"
        };
        string r4 = resp4[random.NextInt64(0, resp4.Length)];
        Console.WriteLine(r4);



        string sql = $@"insert into tbl_encuestado 
        (
	        p1,p1r,
	        p2,p2r,
	        p3,p3r,
	        p4,p4r
        )
        values
        ('{p1}','{r1}',
        '{p2}','{r2}',
        '{p3}','{r3}',
        '{p4}','{r4}'
    );

";

        Microsoft.Data.SqlClient.SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
        con.Close();
    }


}