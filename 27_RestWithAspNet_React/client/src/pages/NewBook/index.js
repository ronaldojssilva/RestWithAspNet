import React, {useEffect, useState} from "react";
import { Link, useNavigate, useParams} from "react-router-dom";
import { FiArrowLeft } from "react-icons/fi";

import api from '../../services/api';

import './styles.css'

import logoImage from '../../assets/logo.svg'

export default function NewBook(){
    
    const [id, setId] = useState(null);
    const [author, setAuthor] = useState('');
    const [title, setTitle] = useState('');
    const [launchDate, setLaunchDate] = useState('');
    const [price, setPrice] = useState('');

    const {bookId} = useParams();

    const navigate = useNavigate();
    
    const accessToken = localStorage.getItem('accessToken');
   
    const authorization =
    {
        headers:{
            Authorization: `Bearer ${accessToken}`
        }
    }

    useEffect(() => {
        if (bookId === '0') return;
        else loadBook();
    }, bookId);

    async function loadBook(){
        try {
            const response = await api.get(`/api/book/v1/${bookId}`, authorization);

            let adjustedDate = response.data.launchDate.split("T", 10)[0];

            setId(response.data.id);
            setTitle(response.data.title);
            setAuthor(response.data.author);
            setPrice(response.data.price);
            setLaunchDate(adjustedDate);

            // "id": 1,
            // "author": "Michael C. Feathers",
            // "launchDate": "2017-11-29T13:50:05.878",
            // "price": 49.00,
            // "title": "Working effectively with legacy code",

        } catch (error) {
            alert('Error recovering book! Try again!' + error);
            navigate('/books');
        }
    }

    async function createNewBook(e){
        e.preventDefault();

        const data = {
            author,
            title,
            launchDate,
            price,
        }

        try {
            await api.post('api/book/v1', data, authorization);

            navigate('/books');
        } catch (error) {
            alert('Error while recording a book! Try again!');
        }
    }


    return(
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Teste" />
                    <h1>Add New Book</h1>
                    <p>Enter the book information and click on 'Add"! ##### ${bookId}</p>
                    <Link className="back-link" to="/books">
                        <FiArrowLeft size={16} color="#251fc5" />
                        Home
                    </Link>
                </section>

                <form onSubmit={createNewBook}>
                    <input 
                        placeholder="Title" 
                        value={title}
                        onChange={e => setTitle(e.target.value)}
                    />
                    <input 
                        placeholder="Author" 
                        value={author}
                        onChange={e => setAuthor(e.target.value)}
                    />
                    <input 
                        type="date" 
                        value={launchDate}
                        onChange={e => setLaunchDate(e.target.value)}
                    />
                    <input 
                        placeholder="Price" 
                        value={price}
                        onChange={e => setPrice(e.target.value)}
                    />

                    <button className="button" type="submit">Add</button>
                </form>
            </div>
        </div>
    );
}