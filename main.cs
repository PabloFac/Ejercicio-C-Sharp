using System;

class MainClass {
  public static void Main (string[] args) {
    
    Test(1, new TimeSpan(12,0,0));
    Test(2, new TimeSpan(6,0,0));
    Test(5, new TimeSpan(3,0,0));
    Test(2, new TimeSpan(24,0,0));
    Test(2, new TimeSpan(48,0,0));
    Test(2, new TimeSpan(7,0,0,0));
    Test(2, new TimeSpan(28,0,0,0));
    Test(1, new TimeSpan(7,1,0,0));
    
  }
  
  public static void Test(int CantidadBicicletas, TimeSpan Tiempo){
    Console.WriteLine("Bicicletas: {0}", CantidadBicicletas);
    Console.WriteLine("Tiempo: {0}", Tiempo.ToString());
    Console.WriteLine("Costo de Alquiler: {0}", CostoDeAlquiler(CantidadBicicletas, Tiempo));
    Console.WriteLine("-");
  }
  
  
  
  public static double CostoDeAlquiler(int CantidadBicicletas, TimeSpan Tiempo){
    
    TimeSpan TIEMPO_UNA_SEMANA = TimeSpan.FromDays(7);
    TimeSpan TIEMPO_UN_DIA = TimeSpan.FromDays(1);
    TimeSpan TIEMPO_UNA_HORA = TimeSpan.FromHours(1);
    
    const int VALOR_ALQUILER_HORA = 20;
    const int VALOR_ALQUILER_DIA = 100;
    const int VALOR_ALQUILER_SEMANA = 500;
    
    double ValorDePeriodo;
    double MultiplicadorDePeriodo;
    
    if (Tiempo >= TIEMPO_UNA_SEMANA){
      ValorDePeriodo = Convert.ToDouble(VALOR_ALQUILER_SEMANA);
      MultiplicadorDePeriodo = (Tiempo.TotalHours / TIEMPO_UNA_SEMANA.TotalHours);
    } else if (Tiempo >= TIEMPO_UN_DIA){
      ValorDePeriodo = Convert.ToDouble(VALOR_ALQUILER_DIA);
      MultiplicadorDePeriodo = (Tiempo.TotalHours / TIEMPO_UN_DIA.TotalHours);
    } else {
      ValorDePeriodo = Convert.ToDouble(VALOR_ALQUILER_HORA);
      MultiplicadorDePeriodo = (Tiempo.TotalHours / TIEMPO_UNA_HORA.TotalHours);
    }
    
    // Redondear a próximo periodo a completar
    MultiplicadorDePeriodo = Math.Ceiling(MultiplicadorDePeriodo);
    
    double Total = (CantidadBicicletas * (ValorDePeriodo * MultiplicadorDePeriodo));
    
    if ((CantidadBicicletas >= 3) && (CantidadBicicletas <= 5)){
      double Descuento = Porcentaje (Total, 30);
      Total = Total - Descuento;
    }
    
    return Total;
  }
  
  public static double Porcentaje(double Total, double Porcentaje){
    return ((Porcentaje * Total) / 100);
  }
  
}