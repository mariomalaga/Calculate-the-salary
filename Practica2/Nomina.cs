using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    class Nomina
    {
        #region Variables
        Empleado empleadoNomina;
        DateTime fechaNomina;
        int numHorasExtras;
        #endregion
        #region Constructores
        public Nomina()
        {
        }
        public Nomina(Empleado empleadoNomina, DateTime fechaNomina, int numHorasExtras)
        {
            this.empleadoNomina = empleadoNomina;
            this.fechaNomina = fechaNomina;
            this.numHorasExtras = numHorasExtras;
        }
        #endregion
        #region Metodos
        #region CotizacionSegDes
        public double CotizacionSegDes()
        {
            double cotizacionSegDes = DevengosPagaExtra() * 1.97 / 100;
            return cotizacionSegDes;
        }
        #endregion
        #region ImporteAntiguedad
        public double ImporteAntiguedad()
        {
            double importeAnt = empleadoNomina.NumTrienios * SalarioBase() * 4 / 100;
            return importeAnt;
        }
        #endregion
        #region SalarioBase
        public double SalarioBase()
        {
            double salarioBase;
            if (empleadoNomina.Categoria == 1)
            {
                salarioBase = 2500;
            }
            else if(empleadoNomina.Categoria == 2){
                salarioBase = 2000;
            }
            else 
            {
                salarioBase = 1500;
            }
            return salarioBase;
        }
        #endregion
        #region ImporteHorasExtras
        public double ImporteHorasExtras()
        {
            double importeHoras = numHorasExtras * SalarioBase() * 1 / 100;
            return importeHoras;
        }
        #endregion
        #region TotalDevengado
        public double TotalDevengado()
        {
            double totalDevengado = SalarioBase() + ImporteAntiguedad() + ImporteHorasExtras();
            return totalDevengado;
        }
        #endregion
        #region TotalDescuentos
        public double TotalDescuentos()
        {
            double totalDescuentos = CotizacionSegDes() + CotizacionSegSoc() + RetencionIRPF();
            return totalDescuentos;
        }
        #endregion
        #region DevengosPagaExtra
        public double DevengosPagaExtra()
        {
            double devengosPagaExtra = SalarioBase() + ImporteAntiguedad();
            return devengosPagaExtra;
        }
        #endregion
        #region CotizacionSegSoc
        public double CotizacionSegSoc()
        {
            double cotizacionSegSoc = (DevengosPagaExtra() + DevengosPagaExtra() / 6) * 4.51 / 100;
            return cotizacionSegSoc;
        }
        #endregion
        #region RetencionIRPF
        public double RetencionIRPF()
        {
            int porcentajeIRPF;
            double retencionIRPF;
            if (empleadoNomina.Categoria == 1)
            {
                porcentajeIRPF = 18 - empleadoNomina.NumHijos;
            }
            else if (empleadoNomina.Categoria == 2)
            {
                porcentajeIRPF = 15 - empleadoNomina.NumHijos;
            }
            else
            {
                porcentajeIRPF = 12 - empleadoNomina.NumHijos;
            }
            if (fechaNomina.Month == 6 || fechaNomina.Month == 12)
            {
                retencionIRPF = (TotalDevengado() + DevengosPagaExtra()) * porcentajeIRPF / 100;
            }
            else
            {
                retencionIRPF = TotalDevengado() * porcentajeIRPF / 100;
            }
            return retencionIRPF;
        }
        #endregion
        #region HojaSalarial
        public void HojaSalarial()
        {
            Console.WriteLine("HOJA SALARIAL");
            Console.WriteLine("LIQUIDACIÓN DE HABERES AL " + fechaNomina.ToString("dd / MM / yyyy"));
            Console.WriteLine("Nombre........: "+empleadoNomina.Nombre);
            Console.WriteLine("NIF...........: "+empleadoNomina.Nif);
            Console.WriteLine("Categoría.....: "+empleadoNomina.Categoria);
            Console.WriteLine("No de Trienios: "+empleadoNomina.NumTrienios);
            Console.WriteLine("No de Hijos...: "+empleadoNomina.NumHijos);
            Console.WriteLine("DEVENGOS                    DESCUENTOS");
            Console.WriteLine("--------                    ----------");
            Console.WriteLine("Salario base "+ Math.Truncate(SalarioBase() * 100) / 100 + "           Cotización Seg.Soc. " + Math.Truncate(CotizacionSegSoc() * 100) / 100);
            Console.WriteLine("Antigüedad " + Math.Truncate(ImporteAntiguedad() * 100) / 100 + "              Cotización Seg.Des. " + Math.Truncate(CotizacionSegDes() * 100) / 100);
            Console.WriteLine("Importe Hor.Ext. " + Math.Truncate(ImporteHorasExtras() * 100) / 100 + "         Retención IRPF " + Math.Truncate(RetencionIRPF() * 100) / 100);
            Console.WriteLine("Paga Extra " + Math.Truncate(DevengosPagaExtra() * 100) / 100 );
            Console.WriteLine("Total Devengos " + TotalDevengado()+ "         Total Descuentos " + Math.Truncate(TotalDescuentos() * 100) / 100);
            Console.WriteLine("----------------------------");
            Console.WriteLine("LIQUIDO A PERCIBIR "+ Math.Truncate(Liquido() * 100) / 100);
            Console.WriteLine("--------------------------------------------------");
        }
        #endregion
        #region Liquido
        public double Liquido()
        {
            double nomina;
            if (fechaNomina.Month == 6 || fechaNomina.Month == 12)
            {
                nomina = TotalDevengado() + DevengosPagaExtra() - TotalDescuentos();
            }
            else
            {
                nomina = TotalDevengado() -TotalDescuentos();
            }
            return nomina;
        }
        #endregion
        #endregion
    }
}
