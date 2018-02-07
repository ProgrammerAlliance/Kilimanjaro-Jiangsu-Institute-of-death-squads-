import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../../actions/actions';
import UpdateUser from './UpdateUser';
import DeleteUser from './DeleteUser';
import AddUser from './AddUser';

export class PersonManage extends Component {
  componentDidMount() {
    this.props.queryAllUser({rows: 10, page: 1});
  }

  render() {
    return (
      <div>
        <div className="fdw-pricing-table">
          <div className="plan plan1">
            <div className="header">
              <h1>用户管理</h1>
            </div>
            {/*<div className="monthly">per month</div>*/}
            <a className="signup" href="#"
               onClick={e => {
                 e.preventDefault();
                 this.props.showAdd('show');
               }}>添加新用户</a>
            <table id="table-5">
              <thead>
              <tr>
                <th>编号:</th>
                <th>姓名:</th>
                <th>卡号:</th>
                <th>部门号:</th>
                <th>密码:</th>
                <th>操作:</th>
              </tr>
              </thead>
              <tbody>
              {this.props.userInfo.list.map((item, index) => {
                return (
                  <tr className="trow" key={index}>
                    <td>{index + 1 + (this.props.userInfo.currentPage - 1) * 10}</td>
                    <td>{item.UserName}</td>
                    <td>{item.UserId}</td>
                    <td>{item.Deptno}:{item.DeptName}</td>
                    <td>{item.UserPwd}</td>
                    <td>
                      <a href="" onClick={e => {
                        e.preventDefault();
                        this.props.showUpdate('show', index);
                      }}>修改</a>
                      |
                      <a href="" onClick={e => {
                        e.preventDefault();
                        this.props.showDelete('show');
                        this.props.saveDelUser(item);
                      }}>删除</a>
                    </td>
                  </tr>
                );
              })}
              </tbody>
            </table>
            <ul className="pagination pagination-lg">
              <li className={this.props.userInfo.currentPage - 1 > 0 ? '' : 'hide'}>
                <a href="#" aria-label="Previous" onClick={e => {
                  e.preventDefault();
                  if (this.props.userInfo.currentPage - 1 > 0) {
                    this.props.queryAllUser({rows: 10, page: this.props.userInfo.currentPage - 1});
                  }
                }}>
                  <span aria-hidden="true">&laquo;</span>
                </a>
              </li>
              {/*<li>{console.log(this.props.totalPage)}</li>*/}
              {this.props.userInfo.totalPage.map((item, index) => {
                return (
                  <li key={index} className={this.props.userInfo.currentPage === index + 1 ? 'active' : ''}>
                    <a href="#" onClick={e => {
                      e.preventDefault();
                      this.props.queryAllUser({rows: 10, page: index + 1});
                    }}>{index + 1}</a>
                  </li>
                );
              })}
              <li className={this.props.userInfo.currentPage < this.props.userInfo.totalPage.length ? '' : 'hide'}>
                <a href="#" aria-label="Next" onClick={e => {
                  e.preventDefault();
                  if (this.props.userInfo.currentPage < this.props.userInfo.totalPage.length) {
                    this.props.queryAllUser({rows: 10, page: this.props.userInfo.currentPage + 1});
                  }
                }}>
                  <span aria-hidden="true">&raquo;</span>
                </a>
              </li>
            </ul>
          </div>
        </div>
        <UpdateUser/>
        <DeleteUser/>
        <AddUser/>
      </div>
    );
  }
}

export default connect(state => state, (dispatch) => bindActionCreators(actionCreators, dispatch))(PersonManage);