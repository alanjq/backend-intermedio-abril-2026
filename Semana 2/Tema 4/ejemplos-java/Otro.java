public class Otro {
    int resultado;

    public Otro(){
        this.resultado = 0;
    }

    public void calcularFecha(){
        Fecha lafecha = new Fecha();
        System.out.println("La fecha: "+ lafecha.dia);
    }
    
    public int Sumar(int valorA, int valorB){
        this.resultado = valorA + valorB;
        return  this.resultado;
    }

}
