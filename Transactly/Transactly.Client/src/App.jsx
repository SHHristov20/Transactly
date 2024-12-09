import React from "react";
// import Navbar from "./Components/Navbar/Navbar";
import { Route, Routes } from "react-router-dom";
import Register from "./Pages/Register";

function App() {
  return (
    <React.Fragment>
      {/* <Navbar /> */}
      <Routes>
        <Route path="/" element={<div>Home</div>} />
        <Route path="/Register" element={<Register />} />
      </Routes>
    </React.Fragment>
  );
}

export default App;
