import React, { Component } from "react";
import SideBar from "./../../common/sidebar";
import NavBar from "./../../common/navbar";

class Terminal extends Component {
  state = {};
  render() {
    return (
      <div>
        <NavBar />
        <SideBar />
        <button>
          <a href="/admin/add-terminal">Add terminal</a>
        </button>
      </div>
    );
  }
}

export default Terminal;
