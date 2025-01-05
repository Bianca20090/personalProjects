package pages;

import database.Category;

import javax.swing.*;

public class App {
    public static void main(String[] args){
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                new TitleScreenGUI().setVisible(true);
                //new CreateQuestion().setVisible(true);
               // new QuizScreen(new Category(1,"Java"),10).setVisible(true);
            }
        });
    }
}
