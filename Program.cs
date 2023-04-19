using System;

int opcion = menu();
int cont = 0;

switch (opcion){
    case 1:
        Boxeador Box1 = crearBoxeador(1);
        cont++;
        break;
    case 2:
        Boxeador Box2 = crearBoxeador(2);
        cont++;
        break;
    case 3:
        if (cont >= 2){
            pelea(Box1, Box2);
        } else {
            Console.WriteLine("Todavia no hay ningun suficientes boxeadores (2) para iniciar una pelea");
        }        
        break;
    case 4:
        Console.Clear();
        Console.WriteLine("Saliendo del programa...");
        break;
}


int menu(){
    Console.WriteLine("*************************************");
    Console.WriteLine("¡Bienvenido a nuestra pelea de Boxeo");
    Console.WriteLine("*************************************");
    Console.WriteLine("Eliga una opción para continuar");
    Console.WriteLine("1. Cargar Datos Boxeador 1");
    Console.WriteLine("2. Cargar Datos Boxeador 2");
    Console.WriteLine("3. Pelear");
    Console.WriteLine("4. Salir");
    return int.Parse(Console.ReadLine());
}

Boxeador crearBoxeador(int n){    
    Console.Clear();
    Console.WriteLine("******************************************");
    Console.WriteLine("Vamos con los datos del Boxeador numero " + n);
    Console.WriteLine("******************************************");
    string nombre = ingresarTexto("Ingrese el nombre");
    string pais = ingresarTexto("Ingrese el pais del boxeador");
    int peso = ingresarEntero("Ahora el peso del boxeador");
    int pg = ingresarEntero("Ahora toca la potencia de golpes del tipo");
    int vp = ingresarEntero("Ahora la velocidad de las piernas");

    return new Boxeador(nombre, pais, peso, pg, vp);
}

void pelea(Boxeador Box1, Boxeador Box2){
    if (Box1.obtenerSkill() > Box2.obtenerSkill()) Console.WriteLine("El ganador es: " + Box1.Nombre);
    if (Box1.obtenerSkill() < Box2.obtenerSkill()) Console.WriteLine("El ganador es: " + Box2.Nombre);
    if (Box1.obtenerSkill() == Box2.obtenerSkill()) Console.WriteLine("¡Es un empate!");
}

int ingresarEntero(string txt){
    Console.WriteLine(txt);
    return int.Parse(Console.ReadLine());
}

string ingresarTexto(string txt){
    Console.WriteLine(txt);
    return Console.ReadLine();
}