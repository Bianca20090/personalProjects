package pages;

import database.JDBC;
import utile.CommonConstants;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class CreateQuestion extends JFrame {
    private JTextArea qArea;
    private JTextField categorietb;
    private JRadioButton[] varianteBtn;
    private ButtonGroup butoane;
    private JTextField[] raspuns;
    public CreateQuestion(){
        super("Create a question");

        setSize(750, 600);
        setLayout(null);

        setLocationRelativeTo(null);
        setResizable(false);
        setDefaultCloseOperation(EXIT_ON_CLOSE);

        //culoare background
        getContentPane().setBackground(CommonConstants.LIGHT_ORANGE);

        varianteBtn=new JRadioButton[4];
        raspuns=new JTextField[4];
        butoane=new ButtonGroup();
        addGuiComponents();
    }

    private void addGuiComponents() {
        JLabel titlu=new JLabel("Create your own question:");
        titlu.setFont(new Font("Arial", Font.BOLD, 24));
        titlu.setBounds(0,20, 390, 29);
        titlu.setHorizontalAlignment(SwingConstants.CENTER);
        titlu.setForeground(CommonConstants.BLUE);
        add(titlu);

        JLabel qlb=new JLabel("Question: ");
        qlb.setFont(new Font("Arial", Font.BOLD, 16));
        qlb.setBounds(10,45, 390, 29);
        qlb.setForeground(CommonConstants.BLUE);
        add(qlb);

        qArea=new JTextArea();
        qArea.setFont(new Font("Arial", Font.BOLD, 16));
        qArea.setBounds(10,75, 390, 100);
        qArea.setForeground(CommonConstants.Green);
        qArea.setLineWrap(true);
        qArea.setWrapStyleWord(true);
        add(qArea);

        JLabel categorie=new JLabel("Category:");
        categorie.setFont(new Font("Arial", Font.BOLD, 16));
        categorie.setBounds(10,200, 390, 29);
        categorie.setForeground(CommonConstants.BLUE);
        add(categorie);

        categorietb=new JTextField();
        categorietb.setFont(new Font("Arial", Font.BOLD, 16));
        categorietb.setBounds(10,240, 390, 29);
        categorietb.setForeground(CommonConstants.BLUE);
        add(categorietb);


        addAnswer();

        JButton salveaza=new JButton("Submit");
        salveaza.setFont(new Font("Arial", Font.BOLD, 16));
        salveaza.setBounds(160,460, 350, 29);
        salveaza.setForeground(CommonConstants.LIGHT_ORANGE);
        salveaza.setBackground(CommonConstants.Green);
        salveaza.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if(validateInput()){
                    String question=qArea.getText();
                    String category=categorietb.getText();
                    String[] variante=new String[raspuns.length];
                    int corectIndex=0;
                    for(int i=0;i< raspuns.length;i++){
                        variante[i]=raspuns[i].getText();
                        if(varianteBtn[i].isSelected()){
                            corectIndex=i;
                        }
                    }


                    //update database

                    if(JDBC.insertQuestionToDBB(question, category, variante, corectIndex)){
                        JOptionPane.showMessageDialog(CreateQuestion.this, "Question added!");
                        resetFields();
                    }
                    else{
                        JOptionPane.showMessageDialog(CreateQuestion.this,"Failed to add question!");
                    }
                }else{
                    JOptionPane.showMessageDialog(CreateQuestion.this, "error invalid input");
                }
            }
        });
        add(salveaza);

        JLabel back=new JLabel("Back");
        back.setFont(new Font("Arial", Font.BOLD, 16));
        back.setBounds(160,490, 350, 29);
        back.setForeground(CommonConstants.Green);
        back.setBackground(CommonConstants.LIGHT_ORANGE);
        back.setHorizontalAlignment(SwingConstants.CENTER);
        back.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                TitleScreenGUI titleScreenGUI=new TitleScreenGUI();
                titleScreenGUI.setLocationRelativeTo(CreateQuestion.this);

                CreateQuestion.this.dispose();
                titleScreenGUI.setVisible(true);
            }
        });
        add(back);

    }



    private void addAnswer() {

        int verticalSpacing=100;
        //variante de raspuns
        for(int i=0;i<4;i++){
            JLabel variantaLb=new JLabel("Answer #" +(i+1));
            variantaLb.setFont(new Font("Arial", Font.BOLD, 16));
            variantaLb.setBounds(470, 60+(i*verticalSpacing), 93, 20);
            variantaLb.setForeground(CommonConstants.BLUE);
            add(variantaLb);

            varianteBtn[i]=new JRadioButton();
            varianteBtn[i].setBounds(440, 100+(i*verticalSpacing), 21, 21);
            varianteBtn[i].setBackground(null);
            butoane.add(varianteBtn[i]);
            add(varianteBtn[i]);


            raspuns[i]=new JTextField();
            raspuns[i].setBounds(470, 90+(i*verticalSpacing), 220, 36);
            raspuns[i].setFont(new Font("Arial", Font.BOLD, 16));
            raspuns[i].setForeground(CommonConstants.PINK);
            add(raspuns[i]);
        }

        varianteBtn[0].setSelected(true);
    }


    private boolean validateInput() {
        if(qArea.getText().replaceAll(" ", "").length()<=0)return false;

        if(categorietb.getText().replaceAll(" ", "").length()<=0) return false;

        for(int i=0;i<raspuns.length;i++){
            if(raspuns[i].getText().replaceAll(" ","").length()<=0)
                return false;
        }

        return true;
    }


    private void resetFields(){
        qArea.setText("");
        categorietb.setText("");
        for(int i=0;i<raspuns.length;i++){
            raspuns[i].setText("");
        }

    }
}
