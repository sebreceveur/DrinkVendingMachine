﻿import { Injectable } from '@angular/core';

@Injectable()
export class MessageService {
  messages: string[] = [];

  add(message: string) {
    if(this.messages.length > 8){
        let tmp = this.messages.slice(1, this.messages.length);
        this.messages = tmp;
    }
    this.messages.push(message);
  }

  clear() {
    this.messages = [];
  }
}