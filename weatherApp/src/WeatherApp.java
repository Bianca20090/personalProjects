import org.json.JSONArray;
import org.json.JSONObject;
import org.json.simple.parser.JSONParser;


import java.net.HttpURLConnection;
import java.net.URL;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class WeatherApp {

    public static JSONObject getWeatherData(String path) {
        JSONArray pathData = getLocationData(path);

        // Extrage longitudinea și latitudinea
        JSONObject location = pathData.getJSONObject(0);
        double latitudine = location.getDouble("latitude");
        double longitudine = location.getDouble("longitude");

        String url = "https://api.open-meteo.com/v1/forecast?"+
                "latitude=" + latitudine +
                "&longitude=" + longitudine +
                "&hourly=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m";

        try {
            HttpURLConnection conn = fetchApiResponse(url);
            if (conn.getResponseCode() != 200) {
                System.out.println("Conexiune eșuată");
                return null;
            }

            StringBuilder resultJson = new StringBuilder();
            Scanner scanner = new Scanner(conn.getInputStream());
            while (scanner.hasNext()) {
                resultJson.append(scanner.nextLine());
            }
            scanner.close();
            conn.disconnect();

            JSONObject resultJsO = new JSONObject(resultJson.toString());
            JSONObject ora = resultJsO.getJSONObject("hourly");
            JSONArray time = ora.getJSONArray("time");
            int index = findIndexOfCurrentTime(time);

            JSONArray temperaturaData = ora.getJSONArray("temperature_2m");
            double temperatura = temperaturaData.getDouble(index);

            JSONArray cod = ora.getJSONArray("weather_code");
            String conditii = convertCod(cod.getLong(index));

            JSONArray umiditate = ora.getJSONArray("relative_humidity_2m");
            long hum = umiditate.getLong(index);

            JSONArray windSpeed = ora.getJSONArray("wind_speed_10m");
            double viteza = windSpeed.getDouble(index);

            // Datele finale despre vreme
            JSONObject dateVreme = new JSONObject();
            dateVreme.put("temperature", temperatura);
            dateVreme.put("conditii", conditii);
            dateVreme.put("umiditate", hum);
            dateVreme.put("viteza", viteza);
            return dateVreme;

        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }


    private static String convertCod(long l) {
        String conditii="";
        if(l==0L){
            conditii="Senin";

        }else if(  l>0L&&l<= 3L){
            conditii="Innorat";
        }
        else if(l>=51L&& l<=67L || l>=80L && l<=99L){
            conditii="Ploaie";
        }
        else if(l>=71L &&l<=77L){
            conditii="Zapada";
        }

return conditii;
    }

    private static int findIndexOfCurrentTime(JSONArray timeL) {
        String currentTime=getCurrentTime();
        for(int i=0;i<timeL.length();i++){
            String time=(String ) timeL.get(i);
            if(time.equalsIgnoreCase(currentTime)){
                return i;
            }

        }
        return 0;
    }

    public static String getCurrentTime() {
        LocalDateTime currentDateTime=LocalDateTime.now();

        DateTimeFormatter format=DateTimeFormatter.ofPattern("yyyy-MM-dd'T'HH':00'");
        String formatDT=currentDateTime.format(format);
        return formatDT;
    }

    public static JSONArray getLocationData(String location) {
        location = location.replaceAll(" ", "+");
        String url = "https://geocoding-api.open-meteo.com/v1/search?name=" + location + "&count=10&language=en&format=json";

        try {
            HttpURLConnection conn = fetchApiResponse(url);
            if (conn.getResponseCode() != 200) {
                System.out.println("Eroare! Conectare la api esuata!");
                return null;
            } else {
                StringBuilder rezultatJson = new StringBuilder();
                Scanner scanner = new Scanner(conn.getInputStream());

                while (scanner.hasNext()) {
                    rezultatJson.append(scanner.nextLine());
                }

                scanner.close();
                conn.disconnect();

                // transformam json string in json obj
                JSONObject rezJO = new JSONObject(rezultatJson.toString());
                JSONArray locationData = rezJO.getJSONArray("results");
                return locationData;
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }

    private static HttpURLConnection fetchApiResponse(String url) {
        try {

            System.setProperty("https.protocols", "TLSv1.2");

            URL urlT = new URL(url);
            HttpURLConnection conn = (HttpURLConnection) urlT.openConnection();
            conn.setRequestMethod("GET");
            conn.connect();
            return conn;
        } catch (Exception e) {
            e.printStackTrace();
        }
        // daca nu se realizeaza conexiunea
        return null;
    }

    public static void main(String[] args) {
        JSONArray data = getLocationData("Tokyo");
        if (data != null) {
            System.out.println(data.toString(2)); // Afiseaza datele intr-un format frumos
        }
    }
}
