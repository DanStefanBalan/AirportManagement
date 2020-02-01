import React, { Component } from "react";
import { getAirports, deleteAirport } from "../../../services/airportService";
import Pagination from "../../common/pagination";
import { paginate } from "../../../helpers/paginate";
import AirportTable from "../../tables/airportTable";
import SearchBox from "../../common/searchBox";
import "../../../styles/tables/airportTable.scss";
import _ from "lodash";

class Airports extends Component {
  state = {
    airports: [],
    pageSize: 10,
    currentPage: 1,
    totalCount: 0,
    searchQuery: "",
    sortColumn: { path: "name", order: "asc" }
  };

  getPagedData = () => {
    const {
      pageSize,
      currentPage,
      sortColumn,
      airports,
      searchQuery
    } = this.state;
    var filteredAirports = airports;
    if (searchQuery)
      filteredAirports = airports.filter(m =>
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
    const { data: airports } = await getAirports();
    const totalCount = airports.length;
    this.setState({ airports, totalCount });
  }

  handleSearch = query => {
    this.setState({ searchQuery: query, currentPage: 1 });
  };

  handlePageChange = page => {
    this.setState({ currentPage: page });
  };

  handleSort = sortColumn => {
    this.setState({ sortColumn });
  };

  handleDelete = airport => {
    const airports = this.state.airports.filter(m => m.id !== airport.id);
    this.setState({ airports });
    deleteAirport(airport.id);
  };

  render() {
    const { length: count } = this.state.airports;
    const { pageSize, currentPage, sortColumn, searchQuery } = this.state;

    if (count === 0) return <p>There are no airports in the database.</p>;

    const { totalCount, data: airports } = this.getPagedData();
    return (
      <React.Fragment>
        <div className="search-row">
          <SearchBox value={searchQuery} onChange={this.handleSearch} />
          <div className="button-wrapper">
            <button className="add-airport">
              <a href="/admin/add-airport">Add airport</a>
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
      </React.Fragment>
    );
  }
}

export default Airports;
