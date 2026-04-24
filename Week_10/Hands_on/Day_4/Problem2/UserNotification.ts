
 
function getWelcomeMessage(name: string): string {
  return `Welcome to our platform, ${name}!`;
}


function getUserInfo(name: string, age?: number): string {
  if (age) {
    return `User: ${name}, Age: ${age}`;
  }
  return `User: ${name}`;
}


const getSubscriptionStatus = (name: string, isSubscribed: boolean = false): string => {
  const status = isSubscribed ? "Active" : "Inactive";
  return `User ${name} has an ${status} subscription.`;
};


const isEligibleForPremium = (age: number): boolean => {
  return age >= 18;
};


const NotificationService = {
  appName: "QuickNotify",
  

  sendNotification: function(userName: string) {
    const formatMessage = (msg: string): string => {
      
      return `[${this.appName}] - ${msg} for ${userName}`;
    };

    return formatMessage("Your account has been updated");
  }
};


console.log("--- Notification System Output ---");


console.log(getWelcomeMessage("Saikumar"));


console.log(getUserInfo("Jaswanth", 24));
console.log(getUserInfo("satish")); 


console.log(getSubscriptionStatus("vinod", true));
console.log(getSubscriptionStatus("vamsi")); 


const userAge = 20;
console.log(`Is ${userAge} eligible for premium? ${isEligibleForPremium(userAge)}`);


console.log(NotificationService.sendNotification("sunil"));