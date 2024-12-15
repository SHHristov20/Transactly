import React from "react";
import { Route, Routes } from "react-router-dom";
import { useUserContext } from "./Components/Context/UserContext";
import Register from "./Pages/Register";
import Login from "./Pages/Login";
import Home from "./Pages/Home";

function App() {
  const { userObject } = useUserContext();

  return (
    <React.Fragment>
      <Routes>
        {userObject !== null && <Route path="/" element={<Home />} />}
        {userObject === null && <Route path="/" element={<Login />} />}
        {userObject === null && (
          <Route path="/Register" element={<Register />} />
        )}
        {userObject === null && <Route path="/Login" element={<Login />} />}
      </Routes>
    </React.Fragment>
  );
}

export default App;
