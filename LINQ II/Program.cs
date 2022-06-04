using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_II
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                COntrolEmpresaEmpleados prueba = new COntrolEmpresaEmpleados();

                Console.WriteLine("Elija el id");

                string elijaID = Console.ReadLine();

                int ElijaIDEmpleado = Convert.ToInt32(elijaID);

                prueba.EmpleadosUnidosEmpresa(ElijaIDEmpleado);

                Console.WriteLine("El programa esta lindo");
            }

            catch(Exception ) 
            {
                Console.WriteLine("Has introducido un Id erroneo por favor escriba un numero");
            }
        }
    }
    class COntrolEmpresaEmpleados
    {
        public COntrolEmpresaEmpleados()
        {
            ListaEmpleados = new List<Empleado>();

            ListaEmpresas = new List<Empresa>();

            ListaEmpresas.Add(new Empresa {id = 1 , Nombre="google" });

            ListaEmpresas.Add(new Empresa { id = 2, Nombre = "PildorasInformaticas" });

            ListaEmpleados.Add(new Empleado { id = 1, Nombre = "Lenny", Cargo = "CEO", empresaID = 1, salaario = 15000 });

            ListaEmpleados.Add(new Empleado { id = 2, Nombre = "Juan", Cargo = "IPA", empresaID = 2, salaario = 35000 });

            ListaEmpleados.Add(new Empleado { id = 3, Nombre = "Yael", Cargo = "ONU", empresaID = 1, salaario = 25000 });

            ListaEmpleados.Add(new Empleado { id = 4, Nombre = "Beleric", Cargo = "ISO", empresaID = 2, salaario = 1055000 });
        }

        public void GetCEO()
        {//Por cada empleado en la lista empleado se usa el empleado que tenga como cargo CEO
            IEnumerable<Empleado> Ceos = from empleado in ListaEmpleados where empleado.Cargo == "CEO" select empleado;

            foreach(Empleado itemEmpleado in Ceos)
            {
                itemEmpleado.getDatosEmpleado();
            }
        }

        public void GetEmpleadosOrdenados()
        {//Por cada empleado en la lista empleado se usa el empleado que tenga como cargo CEO
            //Se especifica tanto en el LINQ como en el foreach el nombre del empleado
            IEnumerable<Empleado> Empleados = from empleado in ListaEmpleados orderby empleado.Nombre descending select empleado;

            foreach (Empleado itemEmpleado in Empleados)
            {
                itemEmpleado.getDatosEmpleado();
            }
        }

        public void EmpleadosUnidosEmpresa( int Id)
        {//Lo unico que cambia de SQL son algunas cosas y tambien que hay que poner el select al final, aqui esto lo que quiere decir que en la lista de empleados una la empresa de la lista empresa
            //donde el id del empleado sea igual al de la empresa y donde tenga como  nombre Pildoras informaticas
            //se usa el id como clave foranea
            //el in se utiliza para a;adir el nombre aqui, por ejemplo pongo una variable y la misma la agrego en la lista de empresas
            IEnumerable<Empleado> EmpleadosPIL = from empleado in ListaEmpleados join Empresasss in ListaEmpresas
                                              on empleado.empresaID equals Empresasss.id
                                              where Empresasss.id == Id select empleado;

            foreach (Empleado itemEmpleado in EmpleadosPIL)
            {
                itemEmpleado.getDatosEmpleado();
            }
        }

        public List<Empresa> ListaEmpresas;

        public List<Empleado> ListaEmpleados;

    }

    class Empresa
    {
        //Para obtener y leer
        public int id { get; set; }

        public string Nombre { get; set; }

        public void getDatosEmpresa()
        {
            Console.WriteLine("Empres {0} con Id {1}", Nombre, id);
        }
    }

    class Empleado
    {
        public int id { get; set; }

        public string Nombre { get; set; }

        public string Cargo { get; set; }

        public double salaario { get; set; }

        //clave foranea una empresa muchos empleados, muchos empleados una empresa

        public int empresaID { get; set; }

        public void getDatosEmpleado()
        {
            Console.WriteLine("Empleado {0} con Id {1}, cargo {2} con salario {3} perteneciente a la empresa " +
                "{4}", Nombre, id, Cargo, salaario,  empresaID);
        }
    }
}
