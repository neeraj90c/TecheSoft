export interface Login {
    group: string;
    date: Date;
    userID: string;
    password: string;
  }
  export interface LoginRequest {
    groupCode: string | null |undefined;
    dateToday: string;
    userName: string| null |undefined;
    userPWD: string| null |undefined;
    dbName: string;
  }
  