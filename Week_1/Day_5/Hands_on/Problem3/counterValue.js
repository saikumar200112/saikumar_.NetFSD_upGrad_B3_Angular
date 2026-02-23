
    var counter=0;
    var displayElement=document.getElementById("p1");
    function incrementcounter(add){
        counter = counter + add;
        update();
    }
    function resetcounter(){
        counter=0;
        update();
    }
    function update(){
       displayElement.innerHTML=counter;
    }
