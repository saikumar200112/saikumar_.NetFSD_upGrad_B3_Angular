

const userName: string = "John Doe";
const email: string = "john.doe@example.com";



let isSubscribed = true; 
let loginAttempts = 0;


let age: number = 25;

age++; 


const isEligibleForPremium: boolean = age > 18 && isSubscribed;


const profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;


console.log("--- User Profile Information ---");
console.log(profileMessage);
console.log(`Subscription Status: ${isSubscribed ? "Active" : "Inactive"}`);
console.log(`Eligible for Premium Plan: ${isEligibleForPremium}`);
console.log(`Login Attempts: ${++loginAttempts}`); 