# waterBuckets

## Guia - Español

### Requerimientos
1. IDE: Visual Studio 2022
2. Framework: .NET 8
### Instalación
1. Abrir Visual Studio.
2. Seleccionar la opcion de clonar repositorio.
3. Configurar las rutas para el proyecto
4. Verificar que el repositorio local se creo.
5. Abrir de nuevo visual studio 2022.
6. Seleccionar opcion de abrir proyecto.
7. Seleccionar proyecto clonado.

###
1. Seleccionar el proyecto waterBuckets y darle ejecutar en modo https o http.

### Descripcion
La tarea es crear una API que calcule los pasos necesarios para obtener una medida exacta de galones de agua, utilizando dos cubetas de capacidades X y Y.
El backend debe de procesar este problema eficientemente y devolver la solución en formato JSON mediante una RESTful API.

#### Condiciones

1. Solo se pueden realizar acciones de llenar, vaciar y transferir el contenido completo de agua una cubeta a otra.
2. Los valores de las capacidades de las cubetas y los gallones solicitados son numeros enteros positivos.
3. El body de la peticion POST para obtener la solución según los valores establecidos tiene la forma de:
   ```
   {
     “x_capacity”:2,
      “y_capacity":10,
      “z_amount_wanted”:4,   
   }
   ```
4. La solucion tiene que ser dada de la siguiente forma:
  ```
  {
"solution": [
{"step": 1, "bucketX": 2, "bucketY": 0, "action": "Fill bucket X"},
{"step": 2, "bucketX": 0, "bucketY": 2, "action": "Transfer from bucket X to Y"},
{"step": 3, "bucketX": 2, "bucketY": 2, "action": "Fill bucket X"},
{"step": 4, "bucketX": 0, "bucketY": 4, "action": "Transfer from bucket X to Y", "status": "Solved"}
]
}
  ```

5. En caso de no encontrar solucion devolver un mensaje indicando que no existe solucion

### Enfoque del algoritmo

Para hallar la solucion primero se estudian los posibles casos donde no sea posible hallar una, presentadose los siguientes:

1. Las capacidades de ambas cubetas son numeros pares y se pide una cantidad impar de galones de agua.
2. La cantidad de galones pedidos es mayor a la capacidad más grande de las cubetas.
3. La cantidad de galones de agua es menor a la capacidad de cualquiera de las dos cubetas, y dividiendo la capacidad de la cubeta mas grande entre la más pequeña no se obtiene un residuo igual a la cantidad de galones solicitado.
4. La cantidad de galones solicitados se encuentra entre las capacidades de las dos cubetas, y se presentan al mismo tiempo los siguientes casos:
   1. La cantidad solicitada de galones no es multiplo de la menor de las capacidades de las cubetas.
   2. La maxima capacidad de las cubetas menos la cantidad solicitada de galones no es multiplo de la menor capacidad de las cubetas.
  
Una vez establecidos los casos donde no sea posible hallar una solución, es más facil demostrar que solo quedan dos patrones de rutas a seguir:

A. 1. Llenar cubeta pequeña -> 2. Pasar contenido a cubeta grande -> repetir desde 1.
B. 1. Llenar cubeta grande -> 2. Restar contenido de la cubeta grande igual a la capacidad de pequeña -> vaciar cubeta pequeña -> repetir desde 2.

Entonces siguiendo ambos patrones por separados se crean dos listas y se agregan los pasos en ellas hasta conseguir la ruta que llego primero a la solucion y la cual tiene la menor cantidad de pasos.

### Descricion de codigo

Aclaro que el codigo siempre distingue la cubeta X como la pequeña y la cubeta Y como la grande y asi se presenta en la solucion independientemente de los valores dados a las capacidades de las cubetas en la peticion.

El codigo para devolver la solucion utiliza un objeto de lista, donde cada elemento agregado a ella es un objeto de la clase Step (Representacion del formato de un paso a la solucion).

```
 public class Step
 {
     //Setter and getters

     public Step(int step, int bucketX, int bucketY, string action)
     {
        ... 
     }
```

La lista se genera dentro de una clase Solution en un metodo privado getSolution con los parametros stepList, int x_capacity, int y_capacity, int z_gallons, donde steplist es una referencia a la lista a devolver; dentro de este metodo se iran agregando los pasos siguiendo por separado ambos patrones mencionados anteriormente y se escogera aquel que halla llegado primero a la solucion. Esta funcion se llamada desde el metodo estatico generate dentro de la misma clase Solution, dentro del cual se filtran los casos donde no es posible hallar una solucion, se crea la instancia de la lista de pasos, y se devuelve la solucion .


```
 public class Solution
 {
     private static void getSolution(ref List<Step> stepList, int x_capacity, int y_capacity, int z_gallons){
    
            //Code to select best solution
         
     }
    static public List<Step> generate(int x_capacity, int y_capacity, int z_gallons) {

         List<Step> stepList = new List<Step>();

         //Code to filter conditions

         return stepList;
     }
 }
```

### Endpoints

Este projecto solo cuenta con un endpoint, su documentacion se encuentra detallado en la pagina generada por Swagger al momento de ejecutarse el projecto.


## Guide - English

 ### Requirements
1. IDE: Visual Studio 2022
2. Framework: .NET 8
### Installation
1. Open Visual Studio.
2. Select the option to clone repository.
3. Configure the paths for the project
4. Verify that the local repository was created.
5. Open visual studio 2022 again.
6. Select open project option.
7. Select cloned project.

###
Select the waterBuckets project and run it in https or http mode.

### Description
The task is to create an API that calculates the necessary steps to obtain an exact measurement of gallons of water, using two buckets of X and Y capacities.
The backend must process this problem efficiently and return the solution in JSON format via a RESTful API.

#### Conditions

1. Only actions of filling, emptying and transferring the entire water content from one bucket to another can be performed.
2. The values of the requested bucket capacities and gallons are positive integers.
3. The body of the POST request to obtain the solution according to the set values has the form of:
  ```
   {
     “x_capacity”:2,
      “y_capacity":10,
      “z_amount_wanted”:4,   
   }
   ```

4. The solution has to be given as follows:
```
{
“solution": [
{“step”: 1, “bucketX”: 2, “bucketY”: 0, “action”: “Fill bucket X”},
{ “step”: 2, “bucketX”: 0, “bucketY”: 2, “action”: “Transfer from bucket X to Y”},
{“step”: 3, “bucketX”: 2, “bucketY”: 2, “action”: “Fill bucket X”},
{“step”: 4, “bucketX”: 0, “bucketY”: 4, “action”: “Transfer from bucket X to Y”, “status”: “Solved”}
]
}
```

5. If no solution is found, return a message indicating that there is no solution.

### Algorithm Approach

To find the solution we first study the possible cases where it is not possible to find a solution, presented as follows:

1. The capacities of both buckets are even numbers and an odd number of gallons of water is requested.
2. The number of gallons ordered is greater than the larger capacity of the buckets.
3. The number of gallons of water is less than the capacity of either bucket, and dividing the capacity of the larger bucket by the smaller bucket does not result in a residual equal to the number of gallons requested.
4. The number of gallons requested is between the capacities of the two buckets, and the following cases occur at the same time:
1. The requested number of gallons is not a multiple of the smaller of the two bucket capacities.
2. The maximum capacity of the buckets minus the requested number of gallons is not a multiple of the smaller capacity of the buckets.

Once the cases where it is not possible to find a solution have been established, it is easier to show that there are only two patterns of routes to follow:

A. 1. Fill small bucket -> 2. Transfer contents to large bucket -> repeat from 1.
B. 1. Fill larger bucket -> 2. Subtract contents of the large bucket equal to the capacity of the small bucket -> empty small bucket -> repeat from 2.

Then following both patterns separately, two lists are created and the steps in them are added until the path that reached the solution first and which has the least amount of steps is reached.

### Code description

Note that the code always distinguishes bucket X as the small bucket and bucket Y as the large bucket and so is presented in the solution regardless of the values given to the bucket capacities in the request.

The code to return the solution uses a list object, where each element added to it is an object of the Step class.

```
 public class Step
 {
     //Setter and getters

     public Step(int step, int bucketX, int bucketY, string action)
     {
        ... 
     }
```

The list is generated inside a Solution class in a private method getSolution with the parameters stepList, x_capacity, y_capacity, and z_gallons, where steplist is a reference to the list to be returned; inside this method the steps will be added following separately both patterns mentioned before and the one that has arrived first to the solution will be chosen. This function is called from the static method generate inside the same Solution class, where the cases where it is not possible to find a solution are filtered, the instance of the list of steps is created, and the solution is returned.

```
 public class Solution
 {
     private static void getSolution(ref List<Step> stepList, int x_capacity, int y_capacity, int z_gallons){
    
            //Code to select best solution
         
     }
    static public List<Step> generate(int x_capacity, int y_capacity, int z_gallons) {

         List<Step> stepList = new List<Step>();

         //Code to filter conditions

         return stepList;
     }
 }
```

### Endpoints

This project has only one endpoint, its documentation is detailed in the page generated by Swagger when the project is executed.
