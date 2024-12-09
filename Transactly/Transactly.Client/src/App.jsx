import React from "react";
import { Route, Routes } from "react-router-dom";
import Register from "./Pages/Register";
import Home from "./Pages/Home";

function App() {
  return (
    <React.Fragment>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/Register" element={<Register />} />
      </Routes>
    </React.Fragment>
  );
}

export default App;
