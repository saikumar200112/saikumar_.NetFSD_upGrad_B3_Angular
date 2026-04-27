
function getFirstElement<T>(items: T[]): T | undefined {
    return items.length > 0 ? items[0] : undefined;
}


interface Repository<T> {
    add(item: T): void;
    getAll(): T[];
}


class DataManager<T> implements Repository<T> {
    private items: T[] = [];

    
    add(item: T): void {
        this.items.push(item);
    }

    
    getAll(): T[] {
        return [...this.items]; 
    }
}


interface User {
    id: number;
    name: string;
}

interface Product {
    id: number;
    title: string;
}



const userManager = new DataManager<User>();
const productManager = new DataManager<Product>();


userManager.add({ id: 1, name: "Saikumar" });
userManager.add({ id: 2, name: "Jaswanth" });


productManager.add({ id: 101, title: "Wireless Mouse" });
productManager.add({ id: 102, title: "Mechanical Keyboard" });


console.log("--- All Users ---");
console.log(userManager.getAll());

console.log("\n--- All Products ---");
console.log(productManager.getAll());


const firstUser = getFirstElement(userManager.getAll());
const firstProduct = getFirstElement(productManager.getAll());

console.log("\n--- First Element Testing ---");
console.log("First User:", firstUser?.name);
console.log("First Product:", firstProduct?.title);