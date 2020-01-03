import React, { Component } from "react";
import NavBar from "./components/common/navbar";
import Footer from "./components/common/footer";
import Home from "./components/home";

class App extends Component {
  state = {};
  render() {
    return (
      <div>
        <NavBar />
        <Home />
        <Footer />
      </div>
    );
  }
}

export default App;
