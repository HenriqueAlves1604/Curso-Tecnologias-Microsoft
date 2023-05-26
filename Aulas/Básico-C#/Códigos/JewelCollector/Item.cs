namespace JewelCollector;

public class Item {
    private string symbol;

    //Constructor:
    public Item (string symbol){
        this.symbol = symbol;
    }

    //toString():
    public void toString(){
        Console.Write(symbol);
    }
}
