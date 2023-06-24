namespace DI{
    public interface Exam{
        public int total();
        public float avg();
    }

    public interface ExamConsole{
        public void Print();
    }
    public class NewlecExam : Exam{
        private int kor;
        private int eng;
        private int math; 

        public override int total(){
            return eng + kor + math;
        }
        public override float avg(){
            return total() / 3;
        }
    }

    public class InlineExamConsole : ExamConsole{
        private Exam exam;
        public void InlineExamConsole(Exam _exam){this.exam = _exam;}
        public void Print() {
            Console.WrtieLine($"{exam.total()} {exam.avg()}");
        }
    }

    public class GridExamConsole : ExamConsole {
        private Exam exam;
        public void InlineExamConsole(Exam _exam){this.exam = _exam;}
        public void Print() {
            Console.WrtieLine($"\n|-------|-------|\n|{exam.total()}|{exam.avg()}|\n|-------|-------|");
        }
    }

    public class Program{

        public static void Main(string[] args){
            Exam exam = new NewlecExam();
            ExamConsole console = new InlineExamConsole();
            ExamConsole console = new GridExamConsole();
        }
    }
}