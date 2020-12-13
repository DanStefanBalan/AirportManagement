import React, { Component } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faPlane,
  faMapMarkedAlt,
  faPlaneDeparture,
  faMapMarkerAlt,
} from "@fortawesome/free-solid-svg-icons";

import "../../styles/sidebar.scss";
import LogoSidebar from "../../resources/images/logo.png";

class SideBar extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }
  render() {
    return (
      <React.Fragment>
        <div className="wrapper-sidebar">
          <div className="image-wrapper">
            <Link to="/">
              <img src={LogoSidebar} className="logo" alt="logo-airport" />
            </Link>
          </div>
          <div className="logo-wrapper">
            <div className="avatar"></div>
            <div className="username">Username</div>
          </div>
          <ul className="list-options">
            <Link to="/admin/aircrafts">
              <li className="option">
                <FontAwesomeIcon rotate="270" icon={faPlane} />
                <div className="text">Aircrafts</div>
              </li>
            </Link>
            <Link to="/admin/destination">
              <li className="option">
                <FontAwesomeIcon icon={faMapMarkedAlt} />
                <div className="text">Destinations</div>
              </li>
            </Link>
            <Link to="/admin/gate">
              <li className="option">
                <FontAwesomeIcon icon={faPlaneDeparture} />
                <div className="text">Gate</div>
              </li>
            </Link>
            <Link to="/admin/terminal">
              <li className="option">
                <FontAwesomeIcon icon={faMapMarkerAlt} />
                <div className="text">Terminals</div>
              </li>
            </Link>
            <Link to="/admin/flight">
              <li className="option">
                <FontAwesomeIcon icon={faPlane} />
                <div className="text">Flight</div>
              </li>
            </Link>
          </ul>
        </div>
      </React.Fragment>
    );
  }
}

export default SideBar;
