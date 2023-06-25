import axios from 'axios'

var axs = axios.create({
    baseURL : 'https://localhost:44350',
});

export function loginAttempt(USurname, UPassword){
    return axs.post("/login",{
        Surname: USurname,
        Password: UPassword
    });
}

