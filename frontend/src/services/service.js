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
    return axs.get('/users/fullname/' + Username);
}

export function getUserBooks(Username){
    return axs.get('/books/' + Username);
}


export function deleteBook(Username,dbId){
    return axs.delete('/books/' + Username + '/' + dbId);
}

export function updateBook(Username, DbId, Title = null, Author = null, BookLanguage = null, PublicationYear = null, 
    Pages = null, Genre = null, FinishingDate = null, Price = null, PersonalRating = null, Notes = null){
    return axs.put("books/" + Username + "/" + DbId,{
        Username: Username,
        Title: Title,
        Author: Author,
        BookLanguage: BookLanguage,
        PublicationYear: PublicationYear,
        Pages: Pages,
        Genre: Genre,
        FinishingDate: FinishingDate,
        Price: Price,
        PersonalRating: PersonalRating,
        Notes: Notes

    });
}
