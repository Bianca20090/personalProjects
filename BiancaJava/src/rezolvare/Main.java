package rezolvare;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {
    public static void main(String[] args) {
        // Exercițiul 1
        String filePath = "automobile.txt";
        List<Automobil> automobile = citesteAutomobile(filePath);
        System.out.println("Automobile cu consum mai mic de 5.5 l/100km:");
        automobile.stream()
                .filter(a -> a.getConsum() < 5.5)
                .sorted(Comparator.comparingDouble(Automobil::getConsum))
                .forEach(System.out::println);

        // Exercițiul 2
        String url = "jdbc:sqlite:C:\\Users\\bianc\\eclipse-workspace\\BiancaJava\\src\\rezolvare\\rental.db";
        Map<String, Integer> inchirieri = citesteInchirieri(url);
        System.out.println("\nClienți cu cel puțin 3 închirieri:");
        inchirieri.entrySet().stream()
                .filter(entry -> entry.getValue() >= 3)
                .forEach(entry -> System.out.println(entry.getKey() + " -> " + entry.getValue()));

        // Exercițiul 3
        Map<String, Integer> totalZileInchiriere = calculeazaZileInchiriere(url);
        String outputPath = "output.txt";
        genereazaFisierInchirieri(outputPath, totalZileInchiriere);
    }

    public static List<Automobil> citesteAutomobile(String filePath) {
        List<Automobil> automobile = new ArrayList<>();
        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {
            String linie;
            while ((linie = br.readLine()) != null) {
                String[] parts = linie.split(",");
                String cod = parts[0];
                String marcaModel = parts[1];
                double consum = Double.parseDouble(parts[2]);
                automobile.add(new Automobil(cod, marcaModel, consum));
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return automobile;
    }

    public static Map<String, Integer> citesteInchirieri(String url) {
        Map<String, Integer> inchirieri = new HashMap<>();
        try (Connection conn = DriverManager.getConnection(url)) {
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery("SELECT id FROM RentACar");

            while (rs.next()) {
                String idClient = rs.getString("id");
                inchirieri.put(idClient, inchirieri.getOrDefault(idClient, 0) + 1);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return inchirieri;
    }

    public static Map<String, Integer> calculeazaZileInchiriere(String url) {
        Map<String, Integer> totalZileInchiriere = new HashMap<>();
        try (Connection conn = DriverManager.getConnection(url)) {
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery("SELECT id, zile FROM RentACar");

            while (rs.next()) {
                String idClient = rs.getString("id");
                int nrZile = rs.getInt("zile");
                totalZileInchiriere.put(idClient, totalZileInchiriere.getOrDefault(idClient, 0) + nrZile);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return totalZileInchiriere;
    }

    public static void genereazaFisierInchirieri(String outputPath, Map<String, Integer> totalZileInchiriere) {
        try (BufferedWriter writer = new BufferedWriter(new FileWriter(outputPath))) {
            writer.write("ID client           Total zile inchiriere\n");
            totalZileInchiriere.entrySet().stream()
                    .sorted((e1, e2) -> e2.getValue().compareTo(e1.getValue()))
                    .forEach(entry -> {
                        try {
                            writer.write(String.format("%-20s %d\n", entry.getKey(), entry.getValue()));
                        } catch (IOException e) {
                            e.printStackTrace();
                        }
                    });
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
