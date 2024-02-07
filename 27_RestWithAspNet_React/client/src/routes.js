import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import Login from "./pages/Login";
import Book from "./pages/Book";

export default function AppRoutes(){
    return (
       <BrowserRouter>
            <Routes>
                <Route path="/" exact element={<Login/>}/>
                <Route path="/book" element={<Book/>}/>
            </Routes>
       </BrowserRouter>
    );
}