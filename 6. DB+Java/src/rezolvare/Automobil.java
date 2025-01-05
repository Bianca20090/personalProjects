package rezolvare;

public class Automobil {
    private String cod;
    private String marcaModel;
    private double consum;

    public Automobil(String cod, String marcaModel, double consum) {
        this.cod = cod;
        this.marcaModel = marcaModel;
        this.consum = consum;
    }

    public String getCod() {
        return cod;
    }

    public String getMarcaModel() {
        return marcaModel;
    }

    public double getConsum() {
        return consum;
    }

    @Override
    public String toString() {
        return String.format("%-10s %-30s %.2f", cod, marcaModel, consum);
    }
}
