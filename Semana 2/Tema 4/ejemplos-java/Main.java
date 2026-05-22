class Main {
    public static void main(String[] args) {
        int MES = 05;
        int YEAR = 2026;
        Fecha hoy = new Fecha(01, MES, YEAR);
        Fecha dentro_de_tres_dias = new Fecha(hoy.getDia() + 3, MES, YEAR);
        Fecha maniana = new Fecha(hoy.getDia() + 1, MES, YEAR);
        Fecha pasado_maniana = new Fecha(hoy.getDia() + 2, MES, YEAR);

        // int resultado = operaciones.Sumar(5,3);

        // unafecha

        System.out.println("Hoy " + hoy.toString());
        System.out.println("Mañana " + maniana.toString());
        System.out.println("Pasado mañana " + pasado_maniana.toString());
        System.out.println("Dentro de tres días " + dentro_de_tres_dias.toString());

    }
}
