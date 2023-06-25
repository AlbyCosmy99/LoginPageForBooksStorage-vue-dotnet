import axios from 'axios'

var axs = axios.create({
    baseURL : 'https://localhost:44350',
});

export function getAXS(url){
    return axs.get("/"+url);
}
export function postDanielsAXS(Dname,Dsurname,Dage){
    return axs.post("/daniel",{
        Name : Dname,
        Surname : Dsurname,
        Age : Dage
    });
}

