import React, {useState} from "react";
import { Link, useNavigate} from "react-router-dom";
import { FiArrowLeft } from "react-icons/fi";

import api from '../../services/api';

import './styles.css'

import logoImage from '../../assets/logo.svg'

export default function NewBook(){
    
    const [author, setAuthor] = useState('');
    const [title, setTitle] = useState('');
    const [launchDate, setLaunchDate] = useState('');
    const [price, setPrice] = useState('');

    const navigate = useNavigate();

    async function createNewBook(e){
        e.preventDefault();

        const data = {
            author,
            title,
            launchDate,
            price,
        }

        const accessToken = localStorage.getItem('accessToken');

        try {
            await api.post('api/book/v1', data, {
                headers:{
                    Authorization: `Bearer ${accessToken}`
                }
            });

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
                    <p>Enter the book information and click on 'Add" !</p>
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