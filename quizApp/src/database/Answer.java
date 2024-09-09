package database;

public class Answer {
    private int answerId;
    private int questionId;
    private String answerText;
    private boolean isTrue;


    public int getAnswerId() {
        return answerId;
    }

    public int getQuestionId() {
        return questionId;
    }

    public String getAnswerText() {
        return answerText;
    }

    public boolean isTrue() {
        return isTrue;
    }

    public Answer(int answerId, int questionId, String answerText, boolean isTrue) {
        this.answerId = answerId;
        this.questionId = questionId;
        this.answerText = answerText;
        this.isTrue = isTrue;
    }
}
