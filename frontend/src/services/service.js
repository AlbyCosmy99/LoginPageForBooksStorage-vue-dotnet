import axios from 'axios'

var axs = axios.create({
    baseURL : 'https://localhost:44350',
});

export function loginAttempt(Username, UPassword){
    return axs.post("/login",{
        Username: Username,
        Password: UPassword
    });
}

