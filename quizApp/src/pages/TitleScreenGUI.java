package pages;

import database.Category;
import database.JDBC;
import utile.CommonConstants;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class TitleScreenGUI extends JFrame {
    private JComboBox categorieCb;
    private JTextField nrQtb;
    public TitleScreenGUI(){
        super("Title Screen");

        setSize(400, 600);
        setLayout(null);

        setLocationRelativeTo(null);
        setResizable(false);
        setDefaultCloseOperation(EXIT_ON_CLOSE);

        //culoare background
        getContentPane().setBackground(CommonConstants.LIGHT_ORANGE);
        addGuiComponents();
    }

    private void addGuiComponents() {

        JLabel titleLb=new JLabel("Quiz");
        titleLb.setFont(new Font("Arial", Font.BOLD, 36));
        titleLb.setBounds(0,20, 390, 43);
        titleLb.setHorizontalAlignment(SwingConstants.CENTER);
        titleLb.setForeground(CommonConstants.BLUE);
        add(titleLb);


        //categorie
        JLabel chCtaeg=new JLabel("Categories");
        chCtaeg.setFont(new Font("Arial", Font.BOLD, 16));
        chCtaeg.setBounds(0,90, 390, 43);
        chCtaeg.setHorizontalAlignment(SwingConstants.CENTER);
        chCtaeg.setForeground(CommonConstants.BLUE);
        add(chCtaeg);


        ArrayList<String> categoryList= JDBC.getCategories();
        categorieCb=new JComboBox(categoryList.toArray());
        categorieCb.setBounds(30, 125, 320, 45);
        categorieCb.setForeground(CommonConstants.Green);
        add(categorieCb);


        JLabel nrQ=new JLabel("Number of question:");
        nrQ.setFont(new Font("Arial", Font.BOLD, 16));
        nrQ.setBounds(10,180, 390, 20);

        nrQ.setForeground(CommonConstants.BLUE);
        add(nrQ);

        nrQtb=new JTextField("1");
        nrQtb.setFont(new Font("Arial", Font.BOLD, 16));
        nrQtb.setBounds(200,180, 148, 26);
        nrQtb.setForeground(CommonConstants.RED);
        add(nrQtb);


        JButton startBtn=new JButton("Start");
        startBtn.setFont(new Font("Arial", Font.BOLD, 16));
        startBtn.setBounds(65,290, 260, 45);
        startBtn.setForeground(CommonConstants.LIGHT_ORANGE);
        startBtn.setBackground(CommonConstants.BLUE);
        startBtn.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if(validateInput()){
                    Category category=JDBC.getCategory(categorieCb.getSelectedItem().toString());
                    if(category==null) return;
                    int numOfQuestions=Integer.parseInt(nrQtb.getText());
                    QuizScreen quizScreen=new QuizScreen(category, numOfQuestions);
                    quizScreen.setLocationRelativeTo(TitleScreenGUI.this);

                    TitleScreenGUI.this.dispose();
                    quizScreen.setVisible(true);
                }
            }
        });
        add(startBtn);

        JButton exitBtn=new JButton("Exit");
        exitBtn.setFont(new Font("Arial", Font.BOLD, 16));
        exitBtn.setBounds(65,350, 260, 45);
        exitBtn.setForeground(CommonConstants.LIGHT_ORANGE);
        exitBtn.setBackground(CommonConstants.BLUE);
        exitBtn.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                TitleScreenGUI.this.dispose();
            }
        });
        add(exitBtn);

        JButton createQ=new JButton("Create a question");
        createQ.setFont(new Font("Arial", Font.BOLD, 16));
        createQ.setBounds(65,410, 260, 45);
        createQ.setForeground(CommonConstants.LIGHT_ORANGE);
        createQ.setBackground(CommonConstants.BLUE);
        createQ.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                //deschidem pagina createquestion
                CreateQuestion createQuestion=new CreateQuestion();
                createQuestion.setLocationRelativeTo(TitleScreenGUI.this);
                TitleScreenGUI.this.dispose();
                createQuestion.setVisible(true);
            }
        });
        add(createQ);




    }

    private boolean validateInput(){
        if(nrQtb.getText().replaceAll(" ", "").length()<=0) return false;
        if(categorieCb.getSelectedItem()==null)return false;

        return true;
    }
}
