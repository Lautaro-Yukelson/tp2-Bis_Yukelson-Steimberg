using System;

List<Boxeador> listaBoxeadores = new List<Boxeador>();
int opcion, cont = 0;

menu(listaBoxeadores);

void menu(List<Boxeador> listaBoxeadores)
{
    Console.Clear();
    Console.WriteLine("*************************************");
    Console.WriteLine("¡Bienvenido a nuestra pelea de Boxeo");
    Console.WriteLine("*************************************");
    Console.WriteLine("Eliga una opción para continuar");
    Console.WriteLine("1. Cargar Datos de Boxeadores");
    Console.WriteLine("2. Modos de Peleas");
    Console.WriteLine("3. Salir");
    int opcion = int.Parse(Console.ReadLine());
    while (opcion < 1 || opcion > 3) opcion = ingresarEntero("Ingrese una opcion valida!");
    switch (opcion)
    {
        case 1:
            listaBoxeadores = ingresarBoxeadores(listaBoxeadores);
            cont++;
            menu(listaBoxeadores);
            break;
        case 2:
            if (cont >= 1) opcionesPeleas(listaBoxeadores);
            else Console.WriteLine("No creaste ningun boxeador, por lo tanto no hay ganador.");
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            break;
    }
}

void opcionesPeleas(List<Boxeador> listaBoxeadores)
{
    Console.Clear();
    Console.WriteLine("************************************");
    Console.WriteLine("Seleccione una opcion de lucha");
    Console.WriteLine("************************************");
    Console.WriteLine("Eliga una opción para continuar");
    Console.WriteLine("1. Pelea todos contra todos");
    Console.WriteLine("2. Pelea personalizada");
    Console.WriteLine("3. Atras");
    Console.WriteLine("4. Salir");
    int opcion = int.Parse(Console.ReadLine());
    while (opcion < 1 || opcion > 3)
    {
        opcion = ingresarEntero("Ingrese una opcion valida!");
    }
    switch (opcion)
    {
        case 1:
            peleaFFA(listaBoxeadores);
            menu(listaBoxeadores);
            break;
        case 2:
            peleaPersonalizada(listaBoxeadores);
            menu(listaBoxeadores);
            break;
        case 3:
            menu(listaBoxeadores);
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            break;

    }
}

List<Boxeador> ingresarBoxeadores(List<Boxeador> listaBoxeadores)
{
    int n = ingresarEntero("¿Cuantos boxeadores va a ingresar?");
    for (int i = 0; i < n; i++)
    {
        int temp = i + 1;
        Console.Clear();
        Console.WriteLine(".:Vamos con el boxeador numero " + temp + " :.");
        string nombre = ingresarTexto("¿Como se llama este boxeador?");
        string pais = ingresarTexto("¿De que pais es este boxeador?");
        int peso = ingresarEntero("¿Cuanto pesa?");
        int pg = ingresarEntero("¿Que potencia de golpe tiene? (1-100)");
        while (pg < 1 || pg > 100) pg = ingresarEntero("Ingrese una potencia valida (1-100)");
        int vp = ingresarEntero("¿Cual es su velocidad de piernas?");
        while (vp < 1 || vp > 100) vp = ingresarEntero("Ingrese una velocidad de pierna valia (1-100)");
        Boxeador box = new Boxeador(nombre, pais, peso, pg, vp);
        listaBoxeadores.Add(box);
    }

    return listaBoxeadores;
}

void peleaFFA(List<Boxeador> listaBoxeadores)
{
    string nombreMejor = "";
    int mayorSkill = -1;
    for (int i = 0; i < listaBoxeadores.Count(); i++)
    {
        if (listaBoxeadores[i].obtenerSkill() > mayorSkill)
        {
            mayorSkill = listaBoxeadores[i].obtenerSkill();
            nombreMejor = listaBoxeadores[i].Nombre;
        }
    }
    Console.WriteLine("El Ganador es...");
    Console.WriteLine("¡" + nombreMejor + "!");
    Console.WriteLine("El se consagro campeon con una skill de " + mayorSkill);
    Console.ReadKey();
}

void peleaPersonalizada(List<Boxeador> listaBoxeadores)
{
    Console.Clear();
    int n = ingresarEntero("¿De cuantos boxeadores será la pelea?");
    while (n > listaBoxeadores.Count())
    {
        n = ingresarEntero("Numero invalido. Queres mas boxeadores de los que cargaste antes. Ingrese un numero valido");
    }
    List<Boxeador> listaParaPelear = new List<Boxeador>();
    for (int i = 0; i < n; i++)
    {
        Console.Clear();
        string nombre = ingresarTexto("Ingrese el nombre del boxeador numero " + (i + 1) + " | Igual que cuando lo creo");
        for (int x = 0; x < listaBoxeadores.Count(); x++)
        {
            if (listaBoxeadores[x].Nombre == nombre)
            {
                listaParaPelear.Add(listaBoxeadores[x]);
            }
        }
    }
    peleaFFA(listaParaPelear);
}

int ingresarEntero(string txt)
{
    Console.WriteLine(txt);
    return int.Parse(Console.ReadLine());
}

string ingresarTexto(string txt)
{
    Console.WriteLine(txt);
    return Console.ReadLine();
}