

import org.json.JSONObject;

import java.awt.Cursor;
import java.awt.Font;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.*;

public class WeatherAppGUI extends JFrame{

    private JSONObject dateVreme;
    public WeatherAppGUI() {
        super("Aplicatie Vreme");

        setDefaultCloseOperation(EXIT_ON_CLOSE);

        setSize(480, 650);

        setLocationRelativeTo(null);

        setResizable(false);

        // Setarea layout-ului pe null pentru poziționare absolută
        setLayout(null);

        addGuiComp();
    }

    private ImageIcon loadImage(String path, int width, int height) {
        ImageIcon originalIcon = new ImageIcon(path);
        Image originalImage = originalIcon.getImage();
        Image scaledImage = originalImage.getScaledInstance(width, height, Image.SCALE_SMOOTH);
        return new ImageIcon(scaledImage);
    }

    private void addGuiComp() {
        JTextField searchTf = new JTextField();
        searchTf.setBounds(15, 15, 351, 45);
        searchTf.setFont(new Font("Dialog", Font.PLAIN, 24));
        add(searchTf);



        // Redimensionarea imaginii pentru condițiile meteo
        JLabel conditiiVremeImg = new JLabel(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatie1\\src\\imgVreme\\cloudy.png", 350, 180));
        conditiiVremeImg.setBounds(8, 125, 450, 217);
        add(conditiiVremeImg);


        //temperatura tb
        JLabel temperaturaTb=new JLabel("10 C");
        temperaturaTb.setBounds(0, 350, 450,54);
        temperaturaTb.setFont(new Font("Dialog", Font.BOLD, 48));
        temperaturaTb.setHorizontalAlignment(SwingConstants.CENTER);
        add(temperaturaTb);



        JLabel descriere=new JLabel("Innorat");
        descriere.setBounds(0, 405, 450,36);
        descriere.setFont(new Font("Dialog", Font.PLAIN, 30));
        descriere.setHorizontalAlignment(SwingConstants.CENTER);
        add(descriere);


        JLabel humImg=new JLabel(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\hum.png", 40, 40));
        humImg.setBounds(15,500, 74, 66);
        add(humImg);

        JLabel humTb=new JLabel("<html><b>Umiditate</b> 100%</html>");
        humTb.setBounds(90, 500, 85, 55);
        humTb.setFont(new Font("Dialog", Font.PLAIN, 16));
        add(humTb);



        JLabel windSpeedImg=new JLabel(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\wind.png", 70, 65));
        windSpeedImg.setBounds(220, 505, 74, 66);
        add(windSpeedImg);

        JLabel windSpeedTb=new JLabel("<html><b>Viteza</b> 15km</html>");
        windSpeedTb.setBounds(300, 500, 85,55);
        windSpeedTb.setFont(new Font("Dialog", Font.PLAIN, 16));
        add(windSpeedTb);


        // Redimensionarea butonului de căutare
        JButton searchBtn = new JButton(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\search.png", 47, 45));
        searchBtn.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        searchBtn.setBounds(375, 13, 47, 45);
        searchBtn.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String inputUser=searchTf.getText();

                if(inputUser.replaceAll("\\s","").length()<=0){
                    return;
                }

                dateVreme=WeatherApp.getWeatherData(inputUser);

                String conditiiVrme=(String) dateVreme.get("conditii");

                switch (conditiiVrme){
                    case "Senin":
                        conditiiVremeImg.setIcon(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\sun.png",350, 180 ));
                        break;


                    case "Innorat":
                        conditiiVremeImg.setIcon(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\cloudy.png",350, 180 ));
                        break;
                    case "Ploaie":
                        conditiiVremeImg.setIcon(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\rain.png",350, 180 ));
                        break;
                    case "Zapada":
                        conditiiVremeImg.setIcon(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\snow.png",350, 180 ));
                        break;
                        /*= new JLabel(loadImage("C:\\Users\\bianc\\eclipse-workspace\\aplicatieVreme\\src\\imgVreme\\cloudy.png", 350, 180));
        conditiiVremeImg.setBounds(8, 125, 450, 217);
        add(conditiiVremeImg);*/
                }

                double temp=(double) dateVreme.get("temperature");
                temperaturaTb.setText(temp+"C");

                descriere.setText(conditiiVrme);
                long umiditate=(long)dateVreme.get("umiditate");
                humTb.setText("<html><b>Umiditate</b>" +umiditate+
                        " %</html>");

                double viteza=(double)dateVreme.get("viteza");
                windSpeedTb.setText("<html><b>Viteza</b>"+viteza+"km</html>");


            }
        });
        add(searchBtn);
    }



}
