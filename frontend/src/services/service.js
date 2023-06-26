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

export function getFullName(Username){
    console.log('right place' + Username)
    return axs.get('/users/fullname/' + Username);
}

