class Boxeador
{
    public string Nombre { get; set; }
    public string Pais { get; set; }
    public int Peso { get; set; }
    public int PotenciaGolpes { get; set; }
    public int VelocidadPiernas { get; set; }

    public Boxeador(string nombre, string pais, int peso, int pg, int vp)
    {
        Nombre = nombre;
        Pais = pais;
        Peso = peso;
        PotenciaGolpes = pg;
        VelocidadPiernas = vp;
    }

    public int obtenerSkill()
    {
        Random rnd = new Random();
        int r = rnd.Next(1, 11);
        int n = VelocidadPiernas + PotenciaGolpes + r;
        return n;
    }
}