import java.util.ArrayList;

class OnlineStockSpan {

    private ArrayList<Integer> prices = new ArrayList<Integer>();

    public OnlineStockSpan() {
        
    }
    
    public int next(int price) {
        this.prices.add(price);
        int span = 0;
        for (int p : this.prices) {
            if (p <= price) {
                span++;
            }
        }
        return span;
    }

    public static void main(String[] args) {
        OnlineStockSpan obj = new OnlineStockSpan();
        int[] inputs = {100, 80, 60, 70, 60, 75, 85};
        for (int input : inputs) {
            System.out.println(input + " " + obj.next(input));
        }
    }
}