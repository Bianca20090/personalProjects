package pages;

import database.Answer;
import database.Category;
import database.JDBC;
import database.Question;
import utile.CommonConstants;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class QuizScreen extends JFrame implements ActionListener {

    private Category category;
    private JButton[] answerButton;
private  JButton nextButton;
    private JTextArea questionTextArea;
    private JLabel scoreEt;
    private ArrayList<Question> questions;
    private Question currentQuestion;
    private int currentQuestionNumber;
    private int numOfQuestions;
    private int score;
    private boolean firstChoice;
    public QuizScreen(Category category, int numOfQ){
        super("QUIZ");

        setSize(400, 600);
        setLayout(null);

        setLocationRelativeTo(null);
        setResizable(false);
        setDefaultCloseOperation(EXIT_ON_CLOSE);

        //culoare background
        getContentPane().setBackground(CommonConstants.LIGHT_ORANGE);

        this.category=category;

        questions= JDBC.getQuesstions(category);

        answerButton=new JButton[4];
        this.numOfQuestions=Math.min(numOfQ, questions.size());

        for(Question question: questions){
            ArrayList<Answer> answers=JDBC.getAnswers(question);
            question.setAnswers(answers);
        }

        if (questions.size() > 0) {
            currentQuestion=questions.get(currentQuestionNumber);
        } else {

            System.out.println("Lista este goală!");
        }
        addGuiComponents();

    }

    private void addGuiComponents() {
        JLabel topicLabel=new JLabel("Category: "+category.getCategoryName());
        topicLabel.setFont(new Font("Arial", Font.BOLD, 16));
        topicLabel.setBounds(15,15,250, 20);
        topicLabel.setForeground(CommonConstants.RED);
        add(topicLabel);



        scoreEt=new JLabel("Score: "+ score+"/"+ numOfQuestions);
        scoreEt.setFont(new Font("Arial", Font.BOLD, 16));
        scoreEt.setBounds(270,15,250, 20);
        scoreEt.setForeground(CommonConstants.RED);
        add(scoreEt);



        questionTextArea=new JTextArea(currentQuestion.getQuestionText());
        questionTextArea.setFont(new Font("Arial", Font.BOLD, 16));
        questionTextArea.setBounds(15,50,350, 91);
        questionTextArea.setForeground(CommonConstants.RED);
        questionTextArea.setBackground(CommonConstants.BLUE);
        questionTextArea.setLineWrap(true);
        questionTextArea.setWrapStyleWord(true);
        questionTextArea.setEditable(false);
        add(questionTextArea);

        addAnswerComponents();

        JButton returnTitleButton=new JButton("Back to home screen");
        returnTitleButton.setFont(new Font("Arial", Font.BOLD, 16));
        returnTitleButton.setBounds(60,420,262, 35);
        returnTitleButton.setBackground(CommonConstants.LIGHT_ORANGE);
        returnTitleButton.setForeground(CommonConstants.Green);
        returnTitleButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                TitleScreenGUI title=new TitleScreenGUI();
                title.setLocationRelativeTo(QuizScreen.this);
                QuizScreen.this.dispose();
                title.setVisible(true);
            }
        });
        add(returnTitleButton);

         nextButton=new JButton("NEXT");
        nextButton.setFont(new Font("Arial", Font.BOLD, 16));
        nextButton.setBounds(240, 470,80, 35);
        nextButton.setBackground(CommonConstants.LIGHT_ORANGE);
        nextButton.setForeground(CommonConstants.Green);
        nextButton.setVisible(false);
        nextButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                nextButton.setVisible(false);
                firstChoice=false;
                currentQuestion=questions.get(++currentQuestionNumber);
                questionTextArea.setText(currentQuestion.getQuestionText());

                for(int i=0;i<currentQuestion.getAnswers().size();i++){
                    Answer answer=currentQuestion.getAnswers().get(i);

                    answerButton[i].setBackground(Color.WHITE);
                    answerButton[i].setText(answer.getAnswerText());
                }
            }
        });
        add(nextButton);



    }

    private void addAnswerComponents() {
        int verticalSpacing=60;

        for(int i=0;i<currentQuestion.getAnswers().size();i++){
            Answer answer=currentQuestion.getAnswers().get(i);

            JButton answerBtn=new JButton(answer.getAnswerText());
            answerBtn.setBounds(60, 180+(i*verticalSpacing), 262, 45);
            answerBtn.setFont(new Font("Arial", Font.BOLD, 18));
            answerBtn.setHorizontalAlignment(SwingConstants.LEFT);
            answerBtn.setBackground(Color.WHITE);
            answerBtn.setForeground(CommonConstants.BLUE);
            answerBtn.addActionListener(this);
            answerButton[i]=answerBtn;
            add(answerButton[i]);
        }


    }

    @Override
    public void actionPerformed(ActionEvent e) {
        JButton answerButton=(JButton) e.getSource();
        Answer correctAns=null;

        for (Answer answer:currentQuestion.getAnswers()){
            if(answer.isTrue()){
                correctAns=answer;
                break;
            }
        }
        if(answerButton.getText().equals(correctAns.getAnswerText())){
            answerButton.setBackground(CommonConstants.Green);
            if(!firstChoice){
                scoreEt.setText("Score: "+(++score)+"/"+numOfQuestions);
            }

            if(currentQuestionNumber==numOfQuestions-1){
                JOptionPane.showMessageDialog(QuizScreen.this, "You're final score is"+
                        score+"/"+numOfQuestions);
            }
            else{
                nextButton.setVisible(true);
            }
        }else{
            answerButton.setBackground((CommonConstants.RED));
        }

        firstChoice=true;
    }
}
