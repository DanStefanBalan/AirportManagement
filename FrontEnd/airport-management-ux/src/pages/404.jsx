import React, { Component } from "react";
import { Link } from "react-router-dom";
import "../styles/pages/404.scss";

class NotFound extends Component {
  render() {
    return (
      <React.Fragment>
        <div className="wrapper-404">
          <div class="image-404">
            <div class="content-wrapper">
              <div class="statement">
                <div className="title">404</div>
                <div className="sub-title">Page not found</div>
              </div>
              <Link to="/">
                <button className="home">Go to homepage</button>
              </Link>
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default NotFound;
