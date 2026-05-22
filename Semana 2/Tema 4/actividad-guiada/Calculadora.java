import java.util.Scanner;

public class Calculadora {

    public static void main(String[] args) {
        char operador;
        double num1, num2, resultado;

        Scanner entrada = new Scanner(System.in);
        System.out.println("Ingresa un operador (+, -, *, /)");
        operador = entrada.next().charAt(0);

        // Evitar pedir números cuando el operador es incorrecto.
        if(operador != '+' && operador != '-' && operador != '*' && operador != '/' ){
            System.out.println("Operador incorrecto");
            System.exit(0);
        }

        // Pedir primer número
        System.out.println("Ingresa el primer número");
        num1 = entrada.nextDouble();

        // Pedir el segundo número
        System.out.println("Ingresa el segundo número");
        num2 = entrada.nextDouble();

        entrada.close();

        // Identificar la operación
        switch (operador) {
            case '+':
                resultado = num1 + num2;
                break;

            case '-': resultado = num1 - num2;
                break;

            case '*': resultado = num1 * num2;
                break;

            case '/': resultado = num1 / num2;
                break;

            default:
                resultado = 0;
                System.out.println("Operador inválido.");
        }

        System.out.println("El resultado es: " + resultado);
    }
}
