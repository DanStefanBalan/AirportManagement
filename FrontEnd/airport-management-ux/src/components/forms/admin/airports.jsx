import React, { Component } from "react";
import { getResources, deleteResource } from "../../../services/api";
import { apiUrl } from "../../../config.json";
import Pagination from "../../common/pagination";
import { paginate } from "../../../helpers/paginate";
import AirportTable from "../../tables/airportTable";
import SearchBox from "../../common/searchBox";
import "../../../styles/table.scss";
import _ from "lodash";
import SideBar from "./../../common/sidebar";
import NavBar from "./../../common/navbar";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import ReactModal from "react-modal";
import AddAirport from "./Add/AddAirport";

const route = `${apiUrl}airports`;

class Airports extends Component {
  state = {
    airports: [],
    pageSize: 10,
    currentPage: 1,
    totalCount: 0,
    searchQuery: "",
    sortColumn: { path: "name", order: "asc" },
  };

  getPagedData = () => {
    const {
      pageSize,
      currentPage,
      sortColumn,
      airports,
      searchQuery,
    } = this.state;
    var filteredAirports = airports;
    if (searchQuery)
      filteredAirports = airports.filter((m) =>
        m.name.toLowerCase().startsWith(searchQuery.toLowerCase())
      );
    const sorted = _.orderBy(
      filteredAirports,
      [sortColumn.path],
      [sortColumn.order]
    );
    const airport = paginate(sorted, currentPage, pageSize);
    return { totalCount: airports.length, data: airport };
  };

  async componentDidMount() {
    const { data: airports } = await getResources(route);
    const totalCount = airports.length;
    this.setState({ airports, totalCount });
  }

  handleSearch = (query) => {
    this.setState({ searchQuery: query, currentPage: 1 });
  };

  handlePageChange = (page) => {
    this.setState({ currentPage: page });
  };

  handleSort = (sortColumn) => {
    this.setState({ sortColumn });
  };

  handleDelete = (airport) => {
    const airports = this.state.airports.filter((m) => m.id !== airport.id);
    this.setState({ airports });
    deleteResource(airport.id, route);
  };

  render() {
    const { pageSize, currentPage, sortColumn, searchQuery } = this.state;
    const { totalCount, data: airports } = this.getPagedData();

    return (
      <React.Fragment>
        <NavBar />
        <SideBar />
        <div className="table-wrapper">
          <div className="search-row">
            <SearchBox
              value={searchQuery}
              onChange={this.handleSearch}
              placeholderText="Search airports..."
            />
            <div className="button-wrapper">
              <button className="add-button">
                <a href="/admin/add-airport">
                  <FontAwesomeIcon icon={faPlus} /> Add airport
                </a>
              </button>
            </div>
          </div>
          <AirportTable
            airports={airports}
            onDelete={this.handleDelete}
            onSort={this.handleSort}
            sortColumn={sortColumn}
          />
          <Pagination
            itemsCount={totalCount}
            pageSize={pageSize}
            currentPage={currentPage}
            onPageChange={this.handlePageChange}
          />
        </div>
      </React.Fragment>
    );
  }
}

export default Airports;
