import React, { useState, useEffect } from "react";
import { Modal } from "react-bootstrap";
import DataTable from "react-data-table-component";
import PageHeader1 from "../../components/common/PageHeader1";
import axios from "../../api/axios";

function UserList() {
  const [table_row, setTable_row] = useState();
  const [ismodal, setIsmodal] = useState(false);
  const [iseditmodal, setIseditmodal] = useState(false);
  const [userID, setUserId] = useState("");
  const [username, setUsername] = useState("");
  const [password, setpassword] = useState("");
  const [fullname, setFullname] = useState("");
  const [email, setEmail] = useState("");
  const [role, setRole] = useState("");
  const getUsers = () => {
    let isMounted = true;
    const controller = new AbortController();
    const get = async () => {
      try {
        const response = await axios.get("/user");
        isMounted && setTable_row(response.data);
      } catch (err) {
        console.error(err);
      }
    };
    get();
    return () => {
      isMounted = false;
      controller.abort();
    };
  };

  useEffect(getUsers, []);

  const handleSubmitAdd = async (e) => {
    e.preventDefault();

    try {
      await axios.put("/user", {
        userID,
        username,
        password,
        fullname,
        email,
        role,
      });
      getUsers();
      setEmail("");
      setFullname("");
      setpassword("");
      setUserId("");
      setUsername("");
      setRole("");
    } catch (err) {
      console.log(err);
    }
  };

  const columns = () => {
    return [
      {
        name: " ID",
        selector: (row) => row.userId,
        sortable: true,
      },
      {
        name: "USER NAME",
        selector: (row) => row.username,
        sortable: true,
      },
      {
        name: "FULL NAME",
        selector: (row) => row.fullname,
        sortable: true,
      },
      {
        name: "FULL NAME",
        selector: (row) => row.role,
        sortable: true,
      },
      {
        name: "MAIL",
        selector: (row) => row.email,
        sortable: true,
      },
      {
        name: "ACTION",
        selector: (row) => {},
        sortable: true,
        cell: (row) => (
          <div
            className="btn-group"
            role="group"
            aria-label="Basic outlined example"
          >
            <button
              onClick={() => {
                setIseditmodal(true);
                setEmail(row.email);
                setFullname(row.fullname);
                setpassword(row.password);
                setUserId(row.userID);
                setUsername(row.username);
                setRole(row.role);
              }}
              type="button"
              className="btn btn-outline-secondary"
            >
              <i className="icofont-edit text-success"></i>
            </button>
            <button
              type="button"
              onClick={() => {
                onDeleteRow(row);
              }}
              className="btn btn-outline-secondary deleterow"
            >
              <i className="icofont-ui-delete text-danger"></i>
            </button>
          </div>
        ),
      },
    ];
  };
  const handleSubmitEdit = async (row, e) => {
    e.preventDefault();

    try {
      console.log(row);
      await axios.post(
        "/user",
        {
          userID,
          username,
          password,
          fullname,
          email,
          role,
        },
        row
      );
      setEmail("");
      setFullname("");
      setpassword("");
      setUserId("");
      setUsername("");
      setRole("");
    } catch (err) {
      console.log(err);
    }
  };
  async function onDeleteRow(row) {
    //eslint-disable-next-line
    var result = await table_row.filter((d) => {
      if (d !== row) {
        return d;
      }
    });

    setTable_row([...result]);
  }

  return (
    <div className="body d-flex py-lg-3 py-md-2">
      <div className="container-xxl">
        <PageHeader1
          pagetitle="Users Information"
          modalbutton={() => {
            return (
              <div className="col-auto d-flex w-sm-100">
                <button
                  type="button"
                  onClick={() => {
                    setIsmodal(true);
                  }}
                  className="btn btn-primary btn-set-task w-sm-100"
                  data-bs-toggle="modal"
                  data-bs-target="#expadd"
                >
                  <i className="icofont-plus-circle me-2 fs-6"></i>Add new user
                </button>
              </div>
            );
          }}
        />
        <div className="row clearfix g-3">
          <div className="col-sm-12">
            <div className="card mb-3">
              <div className="card-body">
                <div
                  id="myProjectTable_wrapper"
                  className="dataTables_wrapper dt-bootstrap5 no-footer"
                >
                  <div className="row">
                    <div className="col-sm-12">
                      <DataTable
                        columns={columns()}
                        data={table_row}
                        defaultSortField="title"
                        pagination
                        selectableRows={false}
                        className="table myDataTable table-hover align-middle mb-0 d-row nowrap dataTable no-footer dtr-inline"
                        highlightOnHover={true}
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <Modal
        show={iseditmodal}
        onHide={() => {
          setIseditmodal(false);
        }}
        className=""
        style={{ display: "block" }}
      >
        <Modal.Header
          className="modal-header"
          closeButton
          onClick={() => {
            setEmail("");
            setFullname("");
            setpassword("");
            setUserId("");
            setUsername("");
            setRole("");
          }}
        >
          <h5 className="modal-title  fw-bold" id="expeditLabel">
            {" "}
            Edit Customers
          </h5>
        </Modal.Header>
        <Modal.Body className="modal-body">
          <div className="deadline-form">
            <form onSubmit={handleSubmitEdit}>
              <div className="row g-3 mb-3">
                <div className="col-sm-12">
                  <label htmlFor="username" className="form-label">
                    user Name
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                  />
                </div>
                <div className="col-sm-12">
                  <label htmlFor="password" className="form-label">
                    password
                  </label>
                  <input
                    type="password"
                    className="form-control"
                    id="password"
                    value={password}
                    onChange={(e) => setpassword(e.target.value)}
                  />
                </div>
              </div>
              <div className="row g-3 mb-3">
                <div className="col-sm-12">
                  <label htmlFor="fullname" className="form-label">
                    fullname
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="fullname"
                    value={fullname}
                    onChange={(e) => setFullname(e.target.value)}
                  />
                </div>
                <div className="col-sm-12">
                  <label htmlFor="email" className="form-label">
                    email
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </div>
              </div>
              <div className="row g-3 mb-3">
                <div className="col-sm-12">
                  <label htmlFor="role" className="form-label">
                    role
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="role"
                    value={role}
                    onChange={(e) => setRole(e.target.value)}
                  />
                </div>
              </div>
              <div className="modal-footer">
                <button
                  type="submit"
                  className="btn btn-primary"
                  onClick={() => {
                    setIsmodal(false);
                  }}
                  data-bs-dismiss="modal"
                >
                  Edit
                </button>
              </div>
            </form>
          </div>
        </Modal.Body>
      </Modal>
      <Modal
        show={ismodal}
        onHide={() => {
          setIsmodal(false);
        }}
        style={{ display: "block" }}
      >
        <Modal.Header
          className="modal-header"
          closeButton
          onClick={() => {
            setEmail("");
            setFullname("");
            setpassword("");
            setUserId("");
            setUsername("");
            setRole("");
          }}
        >
          <h5 className="modal-title  fw-bold" id="expaddLabel">
            Add new User
          </h5>
        </Modal.Header>
        <Modal.Body className="modal-body">
          <div className="deadline-form">
            <form onSubmit={handleSubmitAdd}>
              <div className="row g-3 mb-3">
                <div className="col-sm-12">
                  <label htmlFor="username" className="form-label">
                    user Name
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                  />
                </div>
                <div className="col-sm-12">
                  <label htmlFor="password" className="form-label">
                    password
                  </label>
                  <input
                    type="password"
                    className="form-control"
                    id="password"
                    value={password}
                    onChange={(e) => setpassword(e.target.value)}
                  />
                </div>
              </div>
              <div className="row g-3 mb-3">
                <div className="col-sm-12">
                  <label htmlFor="fullname" className="form-label">
                    fullname
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="fullname"
                    value={fullname}
                    onChange={(e) => setFullname(e.target.value)}
                  />
                </div>
                <div className="col-sm-12">
                  <label htmlFor="email" className="form-label">
                    email
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </div>
              </div>
              <div className="row g-3 mb-3">
                <div className="col-sm-12">
                  <label htmlFor="role" className="form-label">
                    role
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="role"
                    value={role}
                    onChange={(e) => setRole(e.target.value)}
                  />
                </div>
              </div>
              <div className="modal-footer">
                <button
                  type="submit"
                  className="btn btn-primary"
                  onClick={() => {
                    setIsmodal(false);
                  }}
                  data-bs-dismiss="modal"
                >
                  Add
                </button>
              </div>
            </form>
          </div>
        </Modal.Body>
        <Modal.Footer></Modal.Footer>
      </Modal>
    </div>
  );
}
export default UserList;
