public class Fecha{
    private int dia;
    private int mes;
    private int anio;

    public Fecha(){
        this.dia = 21;
        this.mes = 5;
        this.anio = 2026;
    }

    public Fecha(int dia, int mes, int anio){
        this.dia = dia;
        this.mes = mes;
        this.anio = anio;
    }

    public Fecha(int dia){
        this.dia = dia;
    }

    public int getDia(){
        return this.dia;
    }

    public String toString(){
        return this.dia + "/" + this.mes + "/" + this.anio;
    }

}
