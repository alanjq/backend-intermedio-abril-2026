import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Scanner;



public class consumeApi {
    public static void main(String[] args){
        try {
            URL url = new URL("https://jsonplaceholder.typicode.com/users");
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.connect();

            int responseCode = conn.getResponseCode();
            if(responseCode != 200){
                throw new RuntimeException("Ocurrió un error: " + responseCode);
            }else{
                StringBuilder informacionString = new StringBuilder();
                Scanner scanner = new Scanner(url.openStream());

                while(scanner.hasNext()){
                    informacionString.append(scanner.nextLine());
                }

                scanner.close();
                System.out.println(informacionString);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
