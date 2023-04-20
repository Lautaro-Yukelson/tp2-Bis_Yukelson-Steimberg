using System;
bool habilitado = false;

menu();

void menu() {
    Console.Clear();
    Console.WriteLine("*************************************");
    Console.WriteLine("¡Bienvenido a nuestra pelea de Boxeo");
    Console.WriteLine("*************************************");
    Console.WriteLine("Eliga una opción para continuar");
    Console.WriteLine("1. Cargar Datos de Boxeadores");
    Console.WriteLine("2. Carga Aleatoria");
    Console.WriteLine("3. Modos de Peleas");
    Console.WriteLine("4. Editar Luchador");
    Console.WriteLine("5. Salir");
    int opcion = int.Parse(Console.ReadLine());
    while (opcion < 1 || opcion > 5) opcion = ingresarEntero("Ingrese una opcion valida!");
    switch (opcion) {
        case 1:
            ingresarBoxeadores();
            habilitado = true;
            menu();
            break;
        case 2:
            ingresarAleatorios();
            habilitado = true;
            menu();
            break;
        case 3:
            if (habilitado) opcionesPeleas();
            else{
                Console.WriteLine("No creaste ningun boxeador, por lo tanto podemos hacer ninguna pelea.");
                Console.WriteLine("Presione una tecla para continuar...");
            } 
            Console.ReadKey();
            menu();
            break;
        case 4:
            if (habilitado) editarBoxeador();
            else Console.WriteLine("No creaste ningun boxeador, entonces no podes editar nada.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            menu();
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            Console.Clear();
            Environment.Exit(-1);
            break;
    }
}

void opcionesPeleas() {
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
    while (opcion < 1 || opcion > 4) opcion = ingresarEntero("Ingrese una opcion valida!");
    switch (opcion) {
        case 1:
            peleaFFA(Boxeo.listaBoxeadores);
            menu();
            break;
        case 2:
            peleaPersonalizada();
            menu();
            break;
        case 3:
            menu();
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            Console.Clear();
            Environment.Exit(-1);
            break;
    }
}

void ingresarAleatorios(){
    int n = ingresarEntero("¿Cuantos boxeadores va a ingresar?");
    for (int i = 0; i < n; i++) {
        Console.Clear();
        string nombre = $"box{i+1}";
        string pais = $"Pais{i+1}";
        Random rnd = new Random();
        int peso = rnd.Next(1, 151);;
        Random rnd2 = new Random();
        int pg = rnd2.Next(1, 101);
        Random rnd3 = new Random();
        int vp = rnd3.Next(1, 101);
        Boxeador box = new Boxeador(nombre, pais, peso, pg, vp);
        Boxeo.listaBoxeadores.Add(box);
    }
}

void ingresarBoxeadores() {
    int n = ingresarEntero("¿Cuantos boxeadores va a ingresar?");
    for (int i = 0; i < n; i++) {
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
        Boxeo.listaBoxeadores.Add(box);
    }
}

void editarBoxeador(){
    Console.Clear();
    string nombreEditar = ingresarTexto("¿Que boxeador quiere editar? | Ingrese 1 para ver los nombres");
    if (nombreEditar == "1"){
        mostrarBoxeadores();
        nombreEditar = ingresarTexto("Ok, luego de ver los nombres ¿cual es el boxeador que desea editar?");
    } 
    bool existe = false;
    while (!existe){
        for (int i = 0; i<Boxeo.listaBoxeadores.Count(); i++){
            if (Boxeo.listaBoxeadores[i].Nombre == nombreEditar){
                existe = true;
                break;
            }
        }
        if (!existe){
            Console.Clear();
            mostrarBoxeadores();
            nombreEditar = ingresarTexto("Ingrese un nombre valido porfavor...");
        }
    }
    Console.WriteLine("¿Que quiere editar?");
    Console.WriteLine("1. Nombre");
    Console.WriteLine("2. Pais");
    Console.WriteLine("3. Peso");
    Console.WriteLine("4. Potencia del Golpe");
    Console.WriteLine("5. Velocidad de las Piernas");
    Console.WriteLine("6. Atras");
    int opcion = int.Parse(Console.ReadLine());
    while (opcion < 1 || opcion > 6) opcion = ingresarEntero("Ingrese una opcion valida porfavor");
    for (int i = 0; i < Boxeo.listaBoxeadores.Count(); i++) {
        if (Boxeo.listaBoxeadores[i].Nombre == nombreEditar) {
            switch (opcion){
                case 1:
                    Boxeo.listaBoxeadores[i].Nombre = ingresarTexto("Ingrese el nuevo nombre");
                    break;
                case 2:
                    Boxeo.listaBoxeadores[i].Pais = ingresarTexto("¿Cual sera su nuevo pais?");
                    break;
                case 3:
                    Boxeo.listaBoxeadores[i].Peso = ingresarEntero("Ingrese lo que sera el nuevo peso");
                    break;
                case 4:
                    Boxeo.listaBoxeadores[i].PotenciaGolpes = ingresarEntero("¿Cual sera la nueva potencia de golpe?");
                    break;
                case 5:
                    Boxeo.listaBoxeadores[i].VelocidadPiernas = ingresarEntero("¿Cual sera la nueva velocidad de las piernas?");
                    break;
                case 6:
                    menu();
                    break;
            }
            break;
        }
    }
}

void mostrarBoxeadores(){
    Console.Clear();
    Console.WriteLine("Estos son sus boxeadores, ingrese el nombre del que desea modificar");
        for (int i = 0; i<Boxeo.listaBoxeadores.Count()-1; i++){
            Console.Write(Boxeo.listaBoxeadores[i].Nombre + " - ");
        }
    Console.WriteLine(Boxeo.listaBoxeadores[Boxeo.listaBoxeadores.Count()-1].Nombre);
}

void peleaFFA(List<Boxeador> listaParaPelear) {
    string nombreMejor = "";
    int mayorSkill = -1;
    for (int i = 0; i < listaParaPelear.Count(); i++) {
        if (listaParaPelear[i].obtenerSkill() > mayorSkill) {
            mayorSkill = listaParaPelear[i].obtenerSkill();
            nombreMejor = listaParaPelear[i].Nombre;
        }
    }
    if (mayorSkill == -1){
        Console.WriteLine("No hay ganador");
        Console.ReadKey();
    } else {
        Console.WriteLine("El Ganador es...");
        Console.WriteLine("¡" + nombreMejor + "!");
        Console.WriteLine("El se consagro campeon con una skill de " + mayorSkill);
        Console.ReadKey();
    }

}

void peleaPersonalizada() {
    Console.Clear();
    int n = ingresarEntero("¿De cuantos boxeadores será la pelea?");
    while (n > Boxeo.listaBoxeadores.Count()) {
        n = ingresarEntero("Numero invalido. Queres mas boxeadores de los que cargaste antes. Ingrese un numero valido");
    }
    string recordar = (ingresarTexto("Si quiere recordar los nombres escriba SI, de lo contrario escriba NO")).ToLower();
    while (recordar != "si" && recordar != "no"){
        recordar = (ingresarTexto("Opcion invalida. Escriba solo SI o NO para sabe si quiere recordar los nombres")).ToLower();
    }
    if (recordar == "si"){
        for (int i = 0; i<Boxeo.listaBoxeadores.Count()-1; i++){
            Console.Write(Boxeo.listaBoxeadores[i].Nombre + " - ");
        }
        Console.WriteLine(Boxeo.listaBoxeadores[Boxeo.listaBoxeadores.Count()-1].Nombre);
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
    List<Boxeador> listaParaPelear = new List<Boxeador>();
    for (int i = 0; i < n; i++) {
        string nombre = ingresarTexto("Ingrese el nombre del boxeador numero " + (i + 1) + " | Igual que cuando lo creo");
        for (int x = 0; x < Boxeo.listaBoxeadores.Count(); x++) {
            if (Boxeo.listaBoxeadores[x].Nombre == nombre) {
                listaParaPelear.Add(Boxeo.listaBoxeadores[x]);
            }
        }
    }
    peleaFFA(listaParaPelear);
}

int ingresarEntero(string txt) {
    Console.WriteLine(txt);
    return int.Parse(Console.ReadLine());
}

string ingresarTexto(string txt) {
    Console.WriteLine(txt);
    return (Console.ReadLine()).ToLower();
}