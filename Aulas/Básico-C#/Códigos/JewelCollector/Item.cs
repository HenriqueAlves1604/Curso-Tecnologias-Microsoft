namespace JewelCollector;

public class Item {
    private string symbol;
    private bool transpassable;
    private bool collectable;

    //Constructor:
    public Item (string symbol, bool transpassable, bool collectable){
        this.symbol = symbol;
        this.transpassable = transpassable;
        this.collectable = collectable;
    }

    //toString():
    public string toString(){
        return symbol;
    }

    //gets e sets:
    public string getSymbol(){
        return this.symbol;
    }

    public void setSymbol(string symbol){
        this.symbol = symbol;
    }

    public bool getTranspassable(){
        return this.transpassable;
    }

    public void setTranspassable(bool transpassable){
        this.transpassable = transpassable;
    }

    public bool getCollectable(){
        return this.collectable;
    }

    public void setCollectable(bool collectable){
        this.collectable = collectable;
    }
}
