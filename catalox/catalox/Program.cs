using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace catalox
{
    internal class Program
    {
        static Catalogo catalogo = new Catalogo();
        public class Producto
        {
            public int Codigo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
        }
        public class Catalogo
        {
            private Producto[] productos = new Producto[100];
            public void AgregarProducto(Producto producto)
            {
                if (BuscarProducto(producto.Codigo) != null)
                {
                    throw new Exception("El código de producto ya existe");
                }
                for (int i = 0; i < productos.Length; i++)
                {
                    if (productos[i] == null)
                    {
                        productos[i] = producto;
                        break;
                    }
                }
                if (ContinuarAgregando())
                {

                    // Pedir al usuario que ingrese otro producto y llamar al método AgregarProducto de nuevo
                    Console.WriteLine("Ingrese los datos del siguiente producto:");
                    Producto nuevoProducto = new Producto();

                    Console.Write("Ingrese el código del producto: ");
                    nuevoProducto.Codigo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese el nombre del producto: ");
                    nuevoProducto.Nombre = Console.ReadLine();

                    Console.Write("Ingrese la descripción del producto: ");
                    nuevoProducto.Descripcion = Console.ReadLine();

                    Console.Write("Ingrese el precio del producto: ");
                    nuevoProducto.Precio = Convert.ToDouble(Console.ReadLine());

                    AgregarProducto(nuevoProducto);

                }
            }
            public void ActualizarProducto(int codigo)
            {
                Producto producto = BuscarProducto(codigo);

                if (producto == null)
                {
                    throw new Exception("El código de producto no existe");

                }

                // Pedir al usuario que ingrese los nuevos datos del producto y actualizar las propiedades del producto

                if (ContinuarActualizando())
                {
                    // Pedir al usuario que ingrese otro código y llamar al método ActualizarProducto de nuevo
                    Console.Write("Ingrese el nuevo código del producto: ");
                    int nuevoCodigo = Convert.ToInt32(Console.ReadLine());

                    // Actualizar las propiedades del producto
                    producto.Codigo = nuevoCodigo;

                    Console.Write("Ingrese el nuevo nombre del producto: ");
                    producto.Nombre = Console.ReadLine();

                    Console.Write("Ingrese la nueva descripción del producto: ");
                    producto.Descripcion = Console.ReadLine();

                    Console.Write("Ingrese el nuevo precio del producto: ");
                    producto.Precio = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Producto actualizado correctamente.");

                    Console.Write("¿Desa actualizar otro producto? (Sí/No): ");
                    string respuesta = Console.ReadLine().ToLower();
                    int nuevoCodigoActualizar = 0;

                    if (respuesta == "s" || respuesta == "si")
                    {
                        Console.WriteLine("Ingrese el código del producto a actualizar:");
                        nuevoCodigoActualizar = Convert.ToInt32(Console.ReadLine());
                        ActualizarProducto(nuevoCodigoActualizar);
                    }
                    //Console.WriteLine("Ingrese el código del producto a actualizar:");
                    //int nuevoCodigoActualizar = Convert.ToInt32(Console.ReadLine());

                   // ActualizarProducto(nuevoCodigoActualizar);
                }
            }
            public Producto BuscarProducto(int codigo)
            {
                foreach (Producto producto in productos)
                {
                    if (producto != null && producto.Codigo == codigo)
                    {
                        return producto;
                    }
                }
                return null;
            }
            public void MostrarCatalogo()
            {
                foreach (Producto producto in productos)
                {
                    if (producto != null)
                    {
                       
                        // Mostrar los datos del producto por consola
                        Console.WriteLine("Código: " + producto.Codigo);
                        Console.WriteLine("Nombre: " + producto.Nombre);
                        Console.WriteLine("Descripción: " + producto.Descripcion);
                        Console.WriteLine("Precio: " + producto.Precio);
                        Console.WriteLine();
                        //Console.WriteLine("presione una tecla para regresar al menu ");
                        //Console.ReadKey();
                        //Console.Clear();
                    }
                }
            }
            public void EliminarProducto(int codigo)
            {
                Producto producto = BuscarProducto(codigo);

                if (producto == null)
                {
                    throw new Exception("El código de producto no existe");
                }

                if (ConfirmarEliminacion()==true)
                {
                    for (int i = 0; i < productos.Length; i++)
                    {
                        if (productos[i] != null && productos[i].Codigo == codigo)
                        {
                            productos[i] = null;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El codigo no fue eliminado");
                    Console.ReadKey();
                    Console.Clear();
                    
                }
            }
            private bool ContinuarAgregando()
            {

                // Pedir al usuario que confirme si desea agregar otro producto y devolver true o false
                Console.Write("¿Desea agregar otro producto? (Sí/No): ");
                string respuesta = Console.ReadLine().ToLower();

                return respuesta == "sí" || respuesta == "si";

            }
            private bool ContinuarActualizando()
            {
                // Pedir al usuario que confirme si desea actualizar otro producto y devolver true o false
                Console.Write("¿Desa actualizar el producto? (Sí/No): ");
                string respuesta = Console.ReadLine().ToLower();

                return respuesta == "sí" || respuesta == "si";
            }
            private bool ConfirmarEliminacion()
            {
                // Pedir al usuario que confirme si desea eliminar el producto y devolver true o false
                Console.Write("¿Desea eliminar este producto? (Sí/No): ");
                string respuesta = Console.ReadLine().ToLower();

                return respuesta == "sí" || respuesta == "si";
            }
        }
        static void AgregarProducto()
        {
            Producto producto = new Producto();

            Console.Write("Ingrese el código del producto: ");
            producto.Codigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.Write("Ingrese la descripción del producto: ");
            producto.Descripcion = Console.ReadLine();

            Console.Write("Ingrese el precio del producto: ");
            producto.Precio = Convert.ToDouble(Console.ReadLine());

            try
            {
                catalogo.AgregarProducto(producto);
                Console.WriteLine("Producto agregado correctamente");
                Console.Clear();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ActualizarProducto()
        {
            Console.Write("Ingrese el código del producto a actualizar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            try
            {
                catalogo.ActualizarProducto(codigo);
                Console.WriteLine("Producto actualizado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("presione una tecla para regresar al menu ");
            Console.ReadKey();
            Console.Clear();
        }
        static void ConsultarProducto()
        {
            Console.Write("Ingrese el código del producto a consultar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Producto producto = catalogo.BuscarProducto(codigo);

            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado");
            }
            else
            {
                Console.WriteLine("Código: " + producto.Codigo);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Descripción: " + producto.Descripcion);
                Console.WriteLine("Precio: " + producto.Precio);
            }
            Console.WriteLine();
            Console.WriteLine("presione una tecla para regresar al menu ");
            Console.ReadKey();
            Console.Clear();
        }
        static void MostrarCatalogo()
        {
            
            catalogo.MostrarCatalogo();
            
            Console.ReadKey();
            Console.Clear();
        }
        static void EliminarProducto()
        {
            Console.Write("Ingrese el código del producto a eliminar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            try
            {
              
                catalogo.EliminarProducto(codigo);
                Console.WriteLine("Producto eliminado correctamente");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("presione una tecla para regresar al menu ");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Actualizar producto");
                Console.WriteLine("3. Consultar producto");
                Console.WriteLine("4. Mostrar catálogo");
                Console.WriteLine("5. Eliminar producto");
                Console.WriteLine("6. Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        AgregarProducto();
                        break;
                    case 2:
                        Console.Clear();
                        ActualizarProducto();
                        break;
                    case 3:
                        Console.Clear();
                        ConsultarProducto();
                        break;
                    case 4:
                        Console.Clear();
                        MostrarCatalogo();
                        break;
                    case 5:
                        Console.Clear();
                        EliminarProducto();
                        break;
                    case 6:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
    }
}